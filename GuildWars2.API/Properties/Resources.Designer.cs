﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GuildWars2API.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GuildWars2API.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [
        ///  {
        ///    &quot;name&quot;: &quot;Iron Ore&quot;,
        ///    &quot;type&quot;: &quot;CraftingMaterial&quot;,
        ///    &quot;output_item_id&quot;: 19699,
        ///    &quot;output_item_count&quot;: 88,
        ///    &quot;disciplines&quot;: [ &quot;Mystic Forge&quot; ],
        ///    &quot;ingredients&quot;: [
        ///      {
        ///        &quot;item_id&quot;: 19697,
        ///        &quot;count&quot;: 250
        ///      },
        ///      {
        ///        &quot;item_id&quot;: 19699,
        ///        &quot;count&quot;: 1
        ///      },
        ///      {
        ///        &quot;item_id&quot;: 24273,
        ///        &quot;count&quot;: 5
        ///      },
        ///      {
        ///        &quot;item_id&quot;: 20796,
        ///        &quot;count&quot;: 1
        ///      }
        ///    ]
        ///  },
        ///  {
        ///    &quot;name&quot;: &quot;Gold Ore&quot;,
        ///    &quot;type&quot;: &quot;Cra [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string MysticForgeRecipes {
            get {
                return ResourceManager.GetString("MysticForgeRecipes", resourceCulture);
            }
        }
    }
}
