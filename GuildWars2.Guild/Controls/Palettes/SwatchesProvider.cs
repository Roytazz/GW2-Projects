using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace GuildWars2Guild.Controls.Palettes
{
    public static class SwatchesManager
    {
        public static event EventHandler<SwatchEvent> PrimaryChanged;
        public static event EventHandler<SwatchEvent> AccentChanged;

        public static void ApplyPrimary(Swatch swatch) {
            new PaletteHelper().ReplacePrimaryColor(swatch);
            PrimaryChanged(null, new SwatchEvent { Swatch = swatch });
        }

        public static void ApplyAccent(Swatch swatch) {
            new PaletteHelper().ReplaceAccentColor(swatch);
            AccentChanged(null, new SwatchEvent { Swatch = swatch });
        }

        public static IEnumerable<Swatch> GetSwatches() {
            var regex = new Regex(@"^themes\/materialdesigncolor\.(?<name>[a-z]+)\.(?<type>primary|accent)\.baml$");
            var assembly = AppDomain.CurrentDomain.GetAssemblies().Single(ass => ass.GetName().FullName.Contains("MaterialDesignColors"));
            var swatchEntries = GetSwatchEntries(assembly);

            return swatchEntries?
                .Select(x => new { key = x.Key.ToString(), match = regex.Match(x.Key.ToString()) })
                .Where(x => x.match.Success && x.match.Groups["name"].Value != "black")
                .GroupBy(x => x.match.Groups["name"].Value)
                .Select(x =>
                CreateSwatch
                (
                    x.Key,
                    Read(assembly.GetName().Name, x.SingleOrDefault(y => y.match.Groups["type"].Value == "primary")?.key),
                    Read(assembly.GetName().Name, x.SingleOrDefault(y => y.match.Groups["type"].Value == "accent")?.key)
                ))
                .ToList();
        }

        private static Swatch CreateSwatch(string name, ResourceDictionary primaryDictionary, ResourceDictionary accentDictionary) {
            var primaryHues = new List<Hue>();
            var accentHues = new List<Hue>();

            if(primaryDictionary != null) {
                foreach(var entry in primaryDictionary?.OfType<DictionaryEntry>()
                    .OrderBy(de => de.Key)
                    .Where(de => !de.Key.ToString().EndsWith("Foreground", StringComparison.Ordinal))) {
                    var colour = (Color)entry.Value;
                    var foregroundColour = (Color)
                        primaryDictionary.OfType<DictionaryEntry>()
                            .Single(de => de.Key.ToString().Equals(entry.Key.ToString() + "Foreground"))
                            .Value;

                    primaryHues.Add(new Hue(entry.Key.ToString(), colour, foregroundColour));
                }
            }

            if(accentDictionary != null) {
                foreach(var entry in accentDictionary.OfType<DictionaryEntry>()
                    .OrderBy(de => de.Key)
                    .Where(de => !de.Key.ToString().EndsWith("Foreground", StringComparison.Ordinal))) {
                    var colour = (Color)entry.Value;
                    var foregroundColour = (Color)
                        accentDictionary.OfType<DictionaryEntry>()
                            .Single(de => de.Key.ToString().Equals(entry.Key.ToString() + "Foreground"))
                            .Value;

                    accentHues.Add(new Hue(entry.Key.ToString(), colour, foregroundColour));
                }
            }

            return new Swatch(name, primaryHues, accentHues);
        }

        private static ResourceDictionary Read(string assemblyName, string path) {
            if(assemblyName == null || path == null)
                return null;

            return (ResourceDictionary)Application.LoadComponent(new Uri(
                $"/{assemblyName};component/{path.Replace(".baml", ".xaml")}",
                UriKind.RelativeOrAbsolute));
        }

        private static List<DictionaryEntry> GetSwatchEntries(Assembly assembly) {
            if(assembly == null)
                return null;

            var resourcesName = assembly.GetName().Name + ".g";
            var resourceSet = new ResourceManager(resourcesName, assembly).GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            return resourceSet?.OfType<DictionaryEntry>().ToList();
        }
    }

    public class SwatchEvent : EventArgs
    {
        public Swatch Swatch { get; set; }
    }
}