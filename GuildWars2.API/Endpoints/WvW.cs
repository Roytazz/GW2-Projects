using GuildWars2.API.Model.WvW;
using GuildWars2.API.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.API.Endpoints
{
    public static class WvWAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder("wvw"); } }

        #region Abilities
        public static Task<List<int>> AbilityIDs() {
            return Builder.AddDirective("abilities")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Ability>> Abilities(int pageCount, int page) {
            return Builder.AddDirective("abilities")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Ability>>();
        }

        public static Task<Ability> Abilities(int ID) {
            return Builder.AddDirective("abilities")
                .AddDirective(ID.ToString())
                .RequestAsync<Ability>();
        }

        public static Task<List<Ability>> Abilities(List<int> IDs) {
            return Builder.AddDirective("abilities")
                .AddParam("ids", IDs)
                .RequestAsync<List<Ability>>();
        }
        #endregion Abilities

        #region Matches

        #region Current
        public static Task<List<string>> CurrentMatchIDs() {
            return Builder.AddDirective("matches")
                .RequestAsync<List<string>>();
        }

        public static Task<List<MatchDetails>> CurrentMatch(int pageCount, int page) {
            return Builder.AddDirective("matches")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<MatchDetails>>();
        }

        public static Task<MatchDetails> CurrentMatch(string ID) {
            return Builder.AddDirective("matches")
                .AddParam("id", ID)
                .RequestAsync<MatchDetails>();
        }

        public static Task<List<MatchDetails>> CurrentMatch(List<string> IDs) {
            return Builder.AddDirective("matches")
                .AddParam("ids", IDs)
                .RequestAsync<List<MatchDetails>>();
        }

        public static Task<MatchDetails> CurrentMatchByWorld(int worldID) {
            return Builder.AddDirective("matches")
                .AddParam("world", worldID.ToString())
                .RequestAsync<MatchDetails>();
        }
        #endregion Current

        #region Overview
        public static Task<List<string>> MatchOverviewIDs() {
            return Builder.AddDirective("matches")
                .AddDirective("overview")
                .RequestAsync<List<string>>();
        }

        public static Task<List<Match>> MatchOverview(int pageCount, int page) {
            return Builder.AddDirective("matches")
                .AddDirective("overview")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Match>>();
        }

        public static Task<Match> MatchOverview(string ID) { 
            return Builder.AddDirective("matches")
                .AddDirective("overview")
                .AddDirective(ID)
                .RequestAsync<Match>();
        }

        public static Task<List<Match>> MatchOverview(List<string> IDs) {
            return Builder.AddDirective("matches")
                .AddDirective("overview")
                .AddParam("ids", IDs)
                .RequestAsync<List<Match>>();
        }

        public static Task<Match> MatchOverviewByWorld(int worldID) {
            return Builder.AddDirective("matches")
                .AddDirective("overview")
                .AddParam("world", worldID.ToString())
                .RequestAsync<Match>();
        }
        #endregion Overview

        #region Scores
        public static Task<List<string>> MatchScoresIDs() {
            return Builder.AddDirective("matches")
                .AddDirective("scores")
                .RequestAsync<List<string>>();
        }

        public static Task<List<MatchScores>> MatchScores(int pageCount, int page) {
            return Builder.AddDirective("matches")
                .AddDirective("scores")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<MatchScores>>();
        }

        public static Task<MatchScores> MatchScores(string ID) { 
            return Builder.AddDirective("matches")
                .AddDirective("scores")
                .AddDirective(ID)
                .RequestAsync<MatchScores>();
        }

        public static Task<List<MatchScores>> MatchScores(List<string> IDs) {
            return Builder.AddDirective("matches")
                .AddDirective("scores")
                .AddParam("ids", IDs)
                .RequestAsync<List<MatchScores>>();
        }

        public static Task<MatchScores> MatchScoresByWorld(int worldID) {
            return Builder.AddDirective("matches")
                .AddDirective("overview")
                .AddParam("world", worldID.ToString())
                .RequestAsync<MatchScores>();
        }
        #endregion Scores

        #endregion Matches

        #region Objectives
        public static Task<List<string>> ObjectiveIDs() {
            return Builder.AddDirective("objectives")
                .RequestAsync<List<string>>();
        }

        public static Task<List<Objective>> Objectives(int pageCount, int page) {
            return Builder.AddDirective("objectives")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Objective>>();
        }

        public static Task<Objective> Objectives(string ID) {
            return Builder.AddDirective("objectives")
                .AddParam("id", ID)
                .RequestAsync<Objective>();
        }

        public static Task<List<Objective>> Objectives(List<string> IDs) {
            return Builder.AddDirective("objectives")
                .AddParam("ids", IDs)
                .RequestAsync<List<Objective>>();
        }
        #endregion Objectives

        #region Ranks
        public static Task<List<int>> RankIDs() {
            return Builder.AddDirective("ranks")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Rank>> Ranks(int pageCount, int page) {
            return Builder.AddDirective("ranks")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Rank>>();
        }

        public static Task<Rank> Ranks(int ID) { 
            return Builder.AddDirective("ranks")
                .AddDirective(ID.ToString())
                .RequestAsync<Rank>();
        }

        public static Task<List<Rank>> Ranks(List<int> IDs) {
            return Builder.AddDirective("ranks")
                .AddParam("ids", IDs)
                .RequestAsync<List<Rank>>();
        }
        #endregion Ranks

        #region Upgrades
        public static Task<List<int>> UpgradeIDs() {
            return Builder.AddDirective("upgrades")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Upgrade>> Upgrades(int pageCount, int page) {
            return Builder.AddDirective("upgrades")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Upgrade>>();
        }

        public static Task<Upgrade> Upgrades(int ID) {
            return Builder.AddDirective("upgrades")
                .AddDirective(ID.ToString())
                .RequestAsync<Upgrade>();
        }

        public static Task<List<Upgrade>> Upgrades(List<int> IDs) {
            return Builder.AddDirective("upgrades")
                .AddParam("ids", IDs)
                .RequestAsync<List<Upgrade>>();
        }
        #endregion Upgrades
    }
}
