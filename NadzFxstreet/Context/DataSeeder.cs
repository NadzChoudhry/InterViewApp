using Demo.PersistenceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.PersistenceLayer.Context
{
    public static class DataSeeder
    {
        public static void AddData()
        {
            using (FxStreetDemoCtx ctx = new FxStreetDemoCtx())
            {
                IList<Team> teams = new List<Team>();

                teams.Add(new Team()
                {
                    Name = "FC Barcelona"
                });

                teams.Add(new Team()
                {
                    Name = "Real Madrid"
                });

                teams.Add(new Team()
                {
                    Name = "Rcd Español"
                });

                foreach (Team t in teams) ctx.Teams.Add(t);
                ctx.SaveChanges();
            }
            using (var ctx = new FxStreetDemoCtx())
            {

                // Managers
                IList<Manager> managers = new List<Manager>();

                managers.Add(new Manager()
                {
                    Name = "Quique Setién",
                    TeamName = "FC Barcelona",
                    YellowCards = 2,
                    RedCards = 0
                });

                managers.Add(new Manager()
                {
                    Name = "Zinedine Zidane",
                    TeamName = "Real Madrid",
                    YellowCards = 1,
                    RedCards = 1
                });

                managers.Add(new Manager()
                {
                    Name = "Abelardo Fernández",
                    TeamName = "RCD Español",
                    YellowCards = 2,
                    RedCards = 0
                });

                foreach (var m in managers) ctx.Managers.Add(m);
                ctx.SaveChanges();
            }



            #region Player FCB
            using (var ctx = new FxStreetDemoCtx())
            {
                IList<Player> players = new List<Player>();

                ctx.Players.Add(new Player()
                {
                    Name = "Messi",
                    Number = 10,
                    TeamName = "FC Barcelona",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Griezmann",
                    Number = 4,
                    TeamName = "FC Barcelona",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Suarez",
                    Number = 9,
                    TeamName = "FC Barcelona",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {

                    Name = "Ansu Fati",
                    Number = 6,
                    TeamName = "FC Barcelona",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Busquet",
                    Number = 8,
                    TeamName = "FC Barcelona",
                    YellowCards = 0,
                    RedCards = 0
                });
                ctx.Players.Add(new Player()
                {
                    Name = "Iniesta",
                    Number = 22,
                    TeamName = "FC Barcelona",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Abidal",
                    Number = 4,
                    TeamName = "FC Barcelona",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Pujol",
                    Number = 2,
                    TeamName = "FC Barcelona",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {

                    Name = "Ter Stegen",
                    Number = 1,
                    TeamName = "FC Barcelona",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Pedro",
                    Number = 23,
                    TeamName = "FC Barcelona",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Sergio Robert",
                    Number = 24,
                    TeamName = "FC Barcelona",
                    YellowCards = 0,
                    RedCards = 0
                });



                ctx.SaveChanges();
            }
            #endregion

            #region Players Madrid
            using (var ctx = new FxStreetDemoCtx())
            {
                ctx.Players.Add(new Player()
                {
                    Name = "Roberto Carlos",
                    Number = 1,
                    TeamName = "RealMadrid",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Bale",
                    Number = 2,
                    TeamName = "RealMadrid",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "James",
                    Number = 11,
                    TeamName = "RealMadrid",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {

                    Name = "Benzema",
                    Number = 6,
                    TeamName = "RealMadrid",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Marcelo",
                    Number = 8,
                    TeamName = "RealMadrid",
                    YellowCards = 0,
                    RedCards = 0
                });
                ctx.Players.Add(new Player()
                {
                    Name = "Hierro",
                    Number = 50,
                    TeamName = "RealMadrid",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Bekham",
                    Number = 234,
                    TeamName = "RealMadrid",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Morientes",
                    Number = 21,
                    TeamName = "RealMadrid",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {

                    Name = "Sukar",
                    Number = 16,
                    TeamName = "RealMadrid",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Kaka",
                    Number = 18,
                    TeamName = "RealMadrid",
                    YellowCards = 0,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Sergio Ramos",
                    Number = 2,
                    TeamName = "RealMadrid",
                    YellowCards = 0,
                    RedCards = 0
                });
                ctx.SaveChanges();
            }
            #endregion

            #region players Español
            using (var ctx = new FxStreetDemoCtx())
            {
                ctx.Players.Add(new Player()
                {
                    Name = "Wu lei",
                    Number = 1,
                    TeamName = "RCD Español",
                    YellowCards = 3,
                    RedCards = 1
                });
                ctx.Players.Add(new Player()
                {
                    Name = "Raul",
                    Number = 11,
                    TeamName = "RCD Español",
                    YellowCards = 1,
                    RedCards = 2
                });
                ctx.Players.Add(new Player()
                {
                    Name = "Diego Lopez",
                    Number = 2,
                    TeamName = "RCD Español",
                    YellowCards = 3,
                    RedCards = 0
                });
                ctx.Players.Add(new Player()
                {
                    Name = "Jonathan",
                    Number = 21,
                    TeamName = "RCD Español",
                    YellowCards = 6,
                    RedCards = 0
                });
                ctx.Players.Add(new Player()
                {
                    Name = "Marc Roca",
                    Number = 3,
                    TeamName = "RCD Español",
                    YellowCards = 2,
                    RedCards = 0
                });

                ctx.Players.Add(new Player()
                {
                    Name = "Tamudo",
                    Number = 9,
                    TeamName = "RCD Español",
                    YellowCards = 3,
                    RedCards = 1
                });
                ctx.Players.Add(new Player()
                {
                    Name = "Abelardo",
                    Number = 4,
                    TeamName = "RCD Español",
                    YellowCards = 1,
                    RedCards = 2
                });
                ctx.Players.Add(new Player()
                {
                    Name = "Diego Marin",
                    Number = 5,
                    TeamName = "RCD Español",
                    YellowCards = 3,
                    RedCards = 0
                });
                ctx.Players.Add(new Player()
                {
                    Name = "Kameni",
                    Number = 51,
                    TeamName = "RCD Español",
                    YellowCards = 6,
                    RedCards = 0
                });
                ctx.Players.Add(new Player()
                {
                    Name = "Rodrigo",
                    Number = 43,
                    TeamName = "RCD Español",
                    YellowCards = 2,
                    RedCards = 0
                });
                ctx.Players.Add(new Player()
                {
                    Name = "Granero",
                    Number = 45,
                    TeamName = "RCD Español",
                    YellowCards = 2,
                    RedCards = 0
                });
                ctx.SaveChanges();
            }
            #endregion

            using (var ctx = new FxStreetDemoCtx())
            {

                IList<Referee> referees = new List<Referee>();

                referees.Add(new Referee()
                {
                    Name = "Antonio Mateu",
                    MinutesPlayed = 300
                });

                referees.Add(new Referee()
                {

                    Name = "Xavier Estrada",
                    MinutesPlayed = 300
                });

                referees.Add(new Referee()
                {
                    Name = "Guillermo Cuadra",
                    MinutesPlayed = 300
                });

                foreach (var p in referees) ctx.Refrees.Add(p);
                ctx.SaveChanges();
            }

            using (var ctx = new FxStreetDemoCtx())
            {
                IList<Match> matches = new List<Match>();

                List<PlayersOfMatch> listHomies = new List<PlayersOfMatch>();
                List<PlayersOfMatch> listNoHomies = new List<PlayersOfMatch>();

                var homies = ctx.Players.Where(p => p.TeamName == "FC Barcelona").ToList();
                homies?.ForEach((x) =>
                                {
                                    var h = new PlayersOfMatch()
                                    {
                                        Player = x,
                                        PlayerId = x.Id,
                                        Home = true
                                    };
                                    listHomies.Add(h);
                                });

                var noHomies = ctx.Players.Where(p => p.TeamName == "Real Madrid").ToList();
                noHomies?.ForEach(x =>
                                {
                                    var y = new PlayersOfMatch()
                                    {
                                        Player = x,
                                        PlayerId = x.Id,
                                        Home = false
                                    };
                                    listNoHomies.Add(y);
                                });


                matches.Add(new Match()
                {
                    Name = "Barca Madrid",
                    Referee = ctx.Refrees.Where(t => t.Id == 1).FirstOrDefault(),
                    HouseTeamManager = ctx.Managers.Where(t => t.Id == 1).FirstOrDefault(),
                    AwayTeamManager = ctx.Managers.Where(t => t.Id == 2).FirstOrDefault(),
                    HouseTeamPlayers = listHomies,
                    AwayTeamPlayers = listNoHomies,
                    Date = DateTimeOffset.Now,
                });

                listHomies = new List<PlayersOfMatch>();
                listNoHomies = new List<PlayersOfMatch>();

                homies = ctx.Players.Where(p => p.TeamName == "FC Barcelona").ToList();
                homies?.ForEach((x) =>
                                {
                                    var h = new PlayersOfMatch()
                                    {
                                        Player = x,
                                        PlayerId = x.Id,
                                        Home = true
                                    };
                                    listHomies.Add(h);
                                });

                noHomies = ctx.Players.Where(p => p.TeamName == "Real Madrid").ToList();
                noHomies?.ForEach(x =>
                                {
                                    var y = new PlayersOfMatch()
                                    {
                                        Player = x,
                                        PlayerId = x.Id,
                                        Home = false
                                    };
                                    listNoHomies.Add(y);
                                });

                matches.Add(new Match()
                {
                    Name = "Barca Español",
                    Referee = ctx.Refrees.Where(t => t.Id == 2).FirstOrDefault(),
                    HouseTeamManager = ctx.Managers.Where(t => t.Id == 1).FirstOrDefault(),
                    AwayTeamManager = ctx.Managers.Where(t => t.Id == 3).FirstOrDefault(),
                    HouseTeamPlayers = listHomies,
                    AwayTeamPlayers = listNoHomies,
                    Date = DateTimeOffset.Now,
                });

                listHomies = new List<PlayersOfMatch>();
                listNoHomies = new List<PlayersOfMatch>();

                homies = ctx.Players.Where(p => p.TeamName == "Real Madrid").ToList();
                homies?.ForEach((x) =>
                                {
                                    var h = new PlayersOfMatch()
                                    {
                                        Player = x,
                                        PlayerId = x.Id,
                                        Home = true
                                    };
                                    listHomies.Add(h);
                                });

                noHomies = ctx.Players.Where(p => p.TeamName == "RCD Español").ToList();
                noHomies?.ForEach(x =>
                                {
                                    var y = new PlayersOfMatch()
                                    {
                                        Player = x,
                                        PlayerId = x.Id,
                                        Home = false
                                    };
                                    listNoHomies.Add(y);
                                });


                matches.Add(new Match()
                {
                    Name = "Madrid Español",
                    Referee = ctx.Refrees.Where(t => t.Id == 3).FirstOrDefault(),
                    HouseTeamManager = ctx.Managers.Where(t => t.Id == 2).FirstOrDefault(),

                    AwayTeamManager = ctx.Managers.Where(t => t.Id == 3).FirstOrDefault(),

                    HouseTeamPlayers = listHomies,
                    AwayTeamPlayers = listNoHomies,
                    Date = DateTimeOffset.Now,
                });


                listHomies = new List<PlayersOfMatch>();
                listNoHomies = new List<PlayersOfMatch>();

                homies = ctx.Players.Where(p => p.TeamName == "Real Madrid").ToList();
                homies?.ForEach((x) =>
                                {
                                    var h = new PlayersOfMatch()
                                    {
                                        Player = x,
                                        PlayerId = x.Id,
                                        Home = true
                                    };
                                    listHomies.Add(h);
                                });

                noHomies = ctx.Players.Where(p => p.TeamName == "FC Barcelona").ToList();
                noHomies?.ForEach(x =>
                                {
                                    var y = new PlayersOfMatch()
                                    {
                                        Player = x,
                                        PlayerId = x.Id,
                                        Home = false
                                    };
                                    listNoHomies.Add(y);
                                });

                matches.Add(new Match()
                {
                    Name = "Madrid Barca",
                    Referee = ctx.Refrees.Where(t => t.Id == 1).FirstOrDefault(),
                    HouseTeamManager = ctx.Managers.Where(t => t.Id == 2).FirstOrDefault(),
                    AwayTeamManager = ctx.Managers.Where(t => t.Id == 1).FirstOrDefault(),
                    HouseTeamPlayers = listHomies,
                    AwayTeamPlayers = listNoHomies,

                    Date = DateTimeOffset.Now,
                });

                foreach (var p in matches) ctx.Matches.Add(p);
                ctx.SaveChanges();
            }
        }
    }
}
