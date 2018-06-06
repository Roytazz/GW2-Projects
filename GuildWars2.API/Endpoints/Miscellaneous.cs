using GuildWars2.API.Model;
using GuildWars2.API.Model.Miscellaneous;
using GuildWars2.API.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.API
{
    public class MiscellaneousAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Colors
        public static Task<List<int>> ColorIDs()
        {
            return Builder.AddDirective("colors")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Color>> Colors()
        {
            return Builder.AddDirective("colors")
                .AddParam("ids", "all")
                .RequestAsync<List<Color>>();
        }

        public static Task<Color> Colors(int ID)
        {
            return Builder.AddDirective("colors")
                .AddDirective(ID.ToString())
                .RequestAsync<Color>();
        }

        public static Task<List<Color>> Colors(List<int> IDs)
        {
            return Builder.AddDirective("colors")
                .AddParam("ids", IDs)
                .RequestAsync<List<Color>>();
        }
        #endregion Colors

        #region Minis
        public static Task<List<int>> MiniIDs()
        {
            return Builder.AddDirective("minis")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Mini>> Minis()
        {
            return Builder.AddDirective("minis")
                .AddParam("ids", "all")
                .RequestAsync<List<Mini>>();
        }

        public static Task<Mini> Minis(int ID)
        {
            return Builder.AddDirective("minis")
                .AddDirective(ID.ToString())
                .RequestAsync<Mini>();
        }

        public static Task<List<Mini>> Minis(List<int> IDs)
        {
            return Builder.AddDirective("minis")
                .AddParam("ids", IDs)
                .RequestAsync<List<Mini>>();
        }
        #endregion Minis

        #region Titles
        public static Task<List<int>> TitleIDs()
        {
            return Builder.AddDirective("titles")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Title>> Titles()
        {
            return Builder.AddDirective("titles")
                .AddParam("ids", "all")
                .RequestAsync<List<Title>>();
        }

        public static Task<List<Title>> Titles(int pageCount, int page)
        {
            return Builder.AddDirective("titles")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Title>>();
        }

        public static Task<Title> Titles(int ID)
        {
            return Builder.AddDirective("titles")
                .AddDirective(ID.ToString())
                .RequestAsync<Title>();
        }

        public static Task<List<Title>> Titles(List<int> IDs)
        {
            return Builder.AddDirective("titles")
                .AddParam("ids", IDs)
                .RequestAsync<List<Title>>();
        }
        #endregion Titles

        #region Currency
        public static Task<List<int>> CurrencyIDs()
        {
            return Builder.AddDirective("currencies")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Currency>> Currencies()
        {
            return Builder.AddDirective("currencies")
                .AddParam("ids", "all")
                .RequestAsync<List<Currency>>();
        }

        public static Task<Currency> Currencies(int ID)
        {
            return Builder.AddDirective("currencies")
                .AddDirective(ID.ToString())
                .RequestAsync<Currency>();
        }

        public static Task<List<Currency>> Currencies(List<int> IDs)
        {
            return Builder.AddDirective("currencies")
                .AddParam("ids", IDs)
                .RequestAsync<List<Currency>>();
        }
        #endregion Currency

        #region Mastery
        public static Task<List<int>> MasteryIDs()
        {
            return Builder.AddDirective("masteries")
                .RequestAsync<List<int>>();
        }

        public static Task<Mastery> Masteries()
        {
            return Builder.AddDirective("masteries")
                .AddParam("ids", "all")
                .RequestAsync<Mastery>();
        }

        public static Task<Mastery> Masteries(int ID)
        {
            return Builder.AddDirective("masteries")
                .AddDirective(ID.ToString())
                .RequestAsync<Mastery>();
        }

        public static Task<List<Mastery>> Masteries(List<int> IDs)
        {
            return Builder.AddDirective("masteries")
                .AddParam("ids", IDs)
                .RequestAsync<List<Mastery>>();
        }
        #endregion Mastery

        #region Outfits
        public static Task<List<int>> OutfitIDs()
        {
            return Builder.AddDirective("outfits")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Outfit>> Outfits()
        {
            return Builder.AddDirective("outfits")
                .AddParam("ids", "all")
                .RequestAsync<List<Outfit>>();
        }

        public static Task<List<Outfit>> Outfits(int pageCount, int page)
        {
            return Builder.AddDirective("outfits")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Outfit>>();
        }

        public static Task<Outfit> Outfits(int ID)
        {
            return Builder.AddDirective("outfits")
                .AddDirective(ID.ToString())
                .RequestAsync<Outfit>();
        }

        public static Task<List<Outfit>> Outfits(List<int> IDs)
        {
            return Builder.AddDirective("outfits")
                .AddParam("ids", IDs)
                .RequestAsync<List<Outfit>>();
        }
        #endregion Outfits

        #region Files/Assets
        public static Task<List<string>> AssetIDs()
        {
            return Builder.AddDirective("files")
                .RequestAsync<List<string>>();
        }

        public static Task<List<Asset>> Assets()
        {
            return Builder.AddDirective("files")
                .AddParam("ids", "all")
                .RequestAsync<List<Asset>>();
        }

        public static Task<List<Asset>> Assets(int pageCount, int page)
        {
            return Builder.AddDirective("files")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Asset>>();
        }

        public static Task<Asset> Assets(string ID)
        {
            return Builder.AddDirective("files")
                .AddDirective(ID.ToString())
                .RequestAsync<Asset>();
        }

        public static Task<List<Asset>> Assets(List<string> IDs)
        {
            return Builder.AddDirective("files")
                .AddParam("ids", IDs)
                .RequestAsync<List<Asset>>();
        }
        #endregion Files/Assets

        #region Quaggans
        public static Task<List<string>> QuagganIDs()
        {
            return Builder.AddDirective("quaggans")
                .RequestAsync<List<string>>();
        }

        public static Task<List<Asset>> Quaggans()
        {
            return Builder.AddDirective("quaggans")
                .AddParam("ids", "all")
                .RequestAsync<List<Asset>>();
        }

        public static Task<List<Asset>> Quaggans(int pageCount, int page)
        {
            return Builder.AddDirective("quaggans")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Asset>>();
        }

        public static Task<Asset> Quaggans(string ID)
        {
            return Builder.AddDirective("quaggans")
                .AddDirective(ID.ToString())
                .RequestAsync<Asset>();
        }

        public static Task<List<Asset>> Quaggans(List<string> IDs)
        {
            return Builder.AddDirective("quaggans")
                .AddParam("ids", IDs)
                .RequestAsync<List<Asset>>();
        }
        #endregion Quaggans

        #region Worlds
        public static Task<List<int>> WorldIDs()
        {
            return Builder.AddDirective("worlds")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Server>> Worlds()
        {
            return Builder.AddDirective("worlds")
                .AddParam("ids", "all")
                .RequestAsync<List<Server>>();
        }

        public static Task<List<Server>> Worlds(int pageCount, int page)
        {
            return Builder.AddDirective("worlds")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Server>>();
        }

        public static Task<Server> Worlds(int ID)
        {
            return Builder.AddDirective("worlds")
                .AddDirective(ID.ToString())
                .RequestAsync<Server>();
        }

        public static Task<List<Server>> Worlds(List<int> IDs)
        {
            return Builder.AddDirective("worlds")
                .AddParam("ids", IDs)
                .RequestAsync<List<Server>>();
        }
        #endregion Worlds

        #region Pets
        public static Task<List<int>> PetIDs() {
            return Builder.AddDirective("pets")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Pet>> Pets(int pageCount, int page) {
            return Builder.AddDirective("pets")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Pet>>();
        }

        public static Task<Pet> Pets(int ID) {
            return Builder.AddDirective("pets")
                .AddDirective(ID.ToString())
                .RequestAsync<Pet>();
        }

        public static Task<List<Pet>> Pets(List<int> IDs) {
            return Builder.AddDirective("pets")
                .AddParam("ids", IDs)
                .RequestAsync<List<Pet>>();
        }
        #endregion Pets

        #region Dungeons

        public static Task<List<string>> DungeonIDs() {
            return Builder.AddDirective("dungeons")
                .RequestAsync<List<string>>();
        }

        public static Task<List<Dungeon>> Dungeons(int pageCount, int page) {
            return Builder.AddDirective("dungeons")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Dungeon>>();
        }

        public static Task<Dungeon> Dungeons(string ID) {
            return Builder.AddDirective("dungeons")
                .AddDirective(ID.ToString())
                .RequestAsync<Dungeon>();
        }

        public static Task<List<Dungeon>> Dungeons(List<string> IDs) {
            return Builder.AddDirective("dungeons")
                .AddParam("ids", IDs)
                .RequestAsync<List<Dungeon>>();
        }
        #endregion Dungeons

        #region Raids
        public static Task<List<string>> RaidIDs() {
            return Builder.AddDirective("raids")
                .RequestAsync<List<string>>();
        }

        public static Task<List<Raid>> Raids() {
            return Builder.AddDirective("raids")
                .AddParam("ids", "all")
                .RequestAsync<List<Raid>>();
        }

        public static Task<List<Raid>> Raids(int pageCount, int page) {
            return Builder.AddDirective("raids")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Raid>>();
        }

        public static Task<Raid> Raids(string ID) {
            return Builder.AddDirective("raids")
                .AddDirective(ID.ToString())
                .RequestAsync<Raid>();
        }

        public static Task<List<Raid>> Raids(List<string> IDs) {
            return Builder.AddDirective("raids")
                .AddParam("ids", IDs)
                .RequestAsync<List<Raid>>();
        }
        #endregion Raids

        #region Gliders
        public static Task<List<int>> GliderIDs() {
            return Builder.AddDirective("gliders")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Glider>> Gliders(int pageCount, int page) {
            return Builder.AddDirective("gliders")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Glider>>();
        }

        public static Task<Glider> Gliders(int ID) {
            return Builder.AddDirective("gliders")
                .AddDirective(ID.ToString())
                .RequestAsync<Glider>();
        }

        public static Task<List<Glider>> Gliders(List<int> IDs) {
            return Builder.AddDirective("gliders")
                .AddParam("ids", IDs)
                .RequestAsync<List<Glider>>();
        }
        #endregion Gliders

        #region Races
        public static Task<List<Model.Race>> RaceIDs() {
            return Builder.AddDirective("races")
                .RequestAsync<List<Model.Race>>();
        }

        public static Task<List<Model.Miscellaneous.Race>> Races(int pageCount, int page) {
            return Builder.AddDirective("races")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Model.Miscellaneous.Race>>();
        }

        public static Task<Model.Miscellaneous.Race> Races(Model.Race ID) {
            return Builder.AddDirective("races")
                .AddDirective(ID.ToString())
                .RequestAsync<Model.Miscellaneous.Race>();
        }

        public static Task<List<Model.Miscellaneous.Race>> Races(List<Model.Race> IDs) {
            return Builder.AddDirective("races")
                .AddParam("ids", IDs)
                .RequestAsync<List<Model.Miscellaneous.Race>>();
        }
        #endregion

        #region Mail Carriers
        public static Task<List<int>> MailCarrierIDs() {
            return Builder.AddDirective("mailcarriers")
                .RequestAsync<List<int>>();
        }

        public static Task<List<MailCarrier>> MailCarriers(int pageCount, int page) {
            return Builder.AddDirective("mailcarriers")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<MailCarrier>>();
        }

        public static Task<MailCarrier> MailCarriers(int ID) {
            return Builder.AddDirective("mailcarriers")
                .AddDirective(ID.ToString())
                .RequestAsync<MailCarrier>();
        }

        public static Task<List<MailCarrier>> MailCarriers(List<int> IDs) {
            return Builder.AddDirective("mailcarriers")
                .AddParam("ids", IDs)
                .RequestAsync<List<MailCarrier>>();
        }
        #endregion Mail Carriers

        #region Cats
        public static Task<List<int>> CatIDs() {
            return Builder.AddDirective("cats")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Cat>> Cats(int pageCount, int page) {
            return Builder.AddDirective("cats")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Cat>>();
        }

        public static Task<Cat> Cats(int ID) {
            return Builder.AddDirective("cats")
                .AddDirective(ID.ToString())
                .RequestAsync<Cat>();
        }

        public static Task<List<Cat>> Cats(List<int> IDs) {
            return Builder.AddDirective("cats")
                .AddParam("ids", IDs)
                .RequestAsync<List<Cat>>();
        }
        #endregion Cats

        #region Nodes
        public static Task<List<string>> NodeIDs() {
            return Builder.AddDirective("nodes")
                .RequestAsync<List<string>>();
        }

        public static Task<Node> Nodes(string ID) {
            return Builder.AddDirective("nodes")
                .AddDirective(ID.ToString())
                .RequestAsync<Node>();
        }

        public static Task<List<Node>> Nodes(List<string> IDs) {
            return Builder.AddDirective("nodes")
                .AddParam("ids", IDs)
                .RequestAsync<List<Node>>();
        }
        #endregion Nodes

        public static Task<Build> CurrentBuild() {
            return Builder.AddDirective("build")
                .RequestAsync<Build>();
        }
        
        public static Task<TokenInfo> TokenInfo(string apiKey) {
            return Builder.AddDirective("tokeninfo")
                .RequestAsync<TokenInfo>(apiKey);
        }
    }
}