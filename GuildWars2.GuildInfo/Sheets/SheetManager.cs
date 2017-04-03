using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using GuildWars2.GuildInfo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace GuildWars2.GuildInfo.Sheets
{
    internal class SheetManager
    {
        private SheetsService _service;

        public SheetManager() {
            UserCredential credential;

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read)) {
                string credPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new string[] { SheetsService.Scope.Spreadsheets, SheetsService.Scope.SpreadsheetsReadonly },
                    "user",
                    CancellationToken.None).GetAwaiter().GetResult();
                //Console.WriteLine("Credential file saved to: " + credPath);
            }
            _service = new SheetsService(new BaseClientService.Initializer() {
                HttpClientInitializer = credential,
                ApplicationName = "GuildWars2.GuildInfo",
            });
        }

        public void Write<T>(List<T> values, SheetType sheet) where T : ISheetItem {
            ValueRange valueRange = new ValueRange() {
                MajorDimension = "ROWS",
                Values = FlattenCollection(values)
            };
            SpreadsheetsResource.ValuesResource.UpdateRequest update = _service.Spreadsheets.Values.Update(valueRange, GetSheetId(sheet), $"{RangeCreator.CreateRange(values)}");
            update.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            UpdateValuesResponse result = update.Execute();
        }

        private static List<IList<object>> FlattenCollection<T>(List<T> values) where T : ISheetItem {
            List<IList<object>> result = new List<IList<object>> { values[0].Header() };
            values.ForEach(x => result.Add(x.Flatten()));
            return result;
        }

        private static string GetSheetId(SheetType type) {
            switch (type) {
                case SheetType.Roster:
                return "15b1rq6FvDZk8QWboBHCL0yiCorZwI2UJ0_CsuwJYDQ8";
                case SheetType.Squires:
                return "1X7jfE8wwBWrFfBZKuFtr5oeCGE2AVmW-OE46QW-rZqo";
                default:
                return "";
            }
        }
    }

    public enum SheetType
    {
        Roster,
        Squires
    }
}