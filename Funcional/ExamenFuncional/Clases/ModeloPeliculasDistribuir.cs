using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class MovieModel
    {
        public class Movie
        {
            public string Title { get; set; }
            public int Duration { get; set; }
            public string Definition { get; set; }

            public int GenreID { get; set; }
            public int MovieID { get; set; }
            public override string ToString()
            {
                return string.Format("{0} {1} {2} {3}", Title, Duration, Definition, GenreID);
            }

        }
        class Genre
        {
            public string GenreName { get; set; }
            public int GenreID { get; set; }
        }
        class Award
        {
            public string AwardName { get; set; }

            public int AwardID { get; set; }
        }
        class MoviePrize
        {
            public int MovieID { get; set; }
            public int AwardID { get; set; }
            public int Year { get; set; }
        }
        class Actor
        {
            public string Name { get; set; }
            public int ActorID { get; set; }
        }
        class MovieActor
        {
            public int MovieID { get; set; }
            public int ActorID { get; set; }
        }
        List<Movie> movies = new List<Movie>()
        {
            new Movie{Title="El miedo va a cambiar de bando",GenreID=003,Duration=238,Definition="HD",MovieID=001},
            new Movie{Title="La gran estafa I",GenreID=004,Duration=137,Definition="HD",MovieID=002},
            new Movie{Title="La gran estafa II ",GenreID=004,Duration=166,Definition="FHD",MovieID=003},
            new Movie{Title="Nos han quitado hasta el miedo",GenreID=002,Duration=222,Definition="FHD",MovieID=004},
            new Movie{Title="Nos roban todo el Rato",GenreID=003,Duration=37,Definition="UHD",MovieID=005},
            new Movie{Title="1001 formas de buscarse la vida",GenreID=004,Definition="FHD",Duration=145,MovieID=006},
            new Movie{Title="Que te den, Esperanza",GenreID=003,Duration=100,Definition="HD",MovieID=007},
        };

        List<Genre> genres = new List<Genre>
        {
            new Genre{GenreName="Sci-Fi",GenreID=001},
            new Genre{GenreName="Drama",GenreID=002},
            new Genre{GenreName="Comedy",GenreID=003},
            new Genre{GenreName="Documentary",GenreID=004},
        };
        List<Award> awards = new List<Award>()
    {
        new Award{AwardName="Palma de Oro",AwardID=001},
        new Award{AwardName="Oscar a la mejor película en habla no Inglesa",AwardID=002},
        new Award{AwardName="Goya a la mejor película",AwardID=003},
        new Award{AwardName="Oscar al mejor documental", AwardID=004},
    };
        //listado de peliculas y premios
        List<MoviePrize> movieAwards = new List<MoviePrize>()
        {
            new MoviePrize{MovieID=001,AwardID=001,Year=1998},
            new MoviePrize{MovieID=001,AwardID=002,Year=1998},
            new MoviePrize{MovieID=002,AwardID=003,Year=1998},
            new MoviePrize{MovieID=003,AwardID=004,Year=1998},
            new MoviePrize{MovieID=004,AwardID=001,Year=1999},
            new MoviePrize{MovieID=005,AwardID=002,Year=1999},
            new MoviePrize{MovieID=005,AwardID=003,Year=1999},
            new MoviePrize{MovieID=005,AwardID=004,Year=1999}
        };
        //actores
        List<Actor> actors = new List<Actor>()
        {
            new Actor{Name="a, b c",ActorID=001},
            new Actor{Name="d, e f",ActorID=002},
            new Actor{Name="g, h i",ActorID=003},
            new Actor{Name="j, k l",ActorID=004},
            new Actor{Name="m, n o",ActorID=005},
            new Actor{Name="p, q r",ActorID=006},
            new Actor{Name="s, t u",ActorID=007}
        };
        //peliculas y actores
        List<MovieActor> cast = new List<MovieActor>()
        {
            new MovieActor{MovieID=001,ActorID=001},
            new MovieActor{MovieID=001,ActorID=002},
            new MovieActor{MovieID=002,ActorID=003},
            new MovieActor{MovieID=002,ActorID=004},
            new MovieActor{MovieID=002,ActorID=005},
            new MovieActor{MovieID=003,ActorID=001},
            new MovieActor{MovieID=004,ActorID=003},
            new MovieActor{MovieID=004,ActorID=004},
            new MovieActor{MovieID=004,ActorID=005},
            new MovieActor{MovieID=004,ActorID=006},
            new MovieActor{MovieID=005,ActorID=007},
            new MovieActor{MovieID=005,ActorID=001},
            new MovieActor{MovieID=005,ActorID=002},
            new MovieActor{MovieID=006,ActorID=003},
            new MovieActor{MovieID=006,ActorID=005},
            new MovieActor{MovieID=007,ActorID=001},
            new MovieActor{MovieID=007,ActorID=002},
            new MovieActor{MovieID=007,ActorID=003},
            new MovieActor{MovieID=007,ActorID=004},
            new MovieActor{MovieID=007,ActorID=005},
        };
        //Definir métodos preguntas LINQ aquí
        //ejemplo
        public void películasPorActor()
        {
            var consulta = actors
                //unir con el reparto para saber el ID de las películas
                .Join(cast, a => a.ActorID, c => c.ActorID, (a, c) => new { actor = a, MovieID = c.MovieID })
                //unir con la lista de películas para saber el título
                .Join(movies, a => a.MovieID, m => m.MovieID, (a, m) => new { Name = a.actor.Name, Title = m.Title })
                //agrupar por actores
                .GroupBy(x => x.Name, x => new { Title = x.Title });
            foreach (var x in consulta)
            {
                //Key es el nombre de cada uno de ellos
                Console.WriteLine(x.Key);
                //cada elemento de x es el título de una película de x.Key
                foreach (var y in x)
                    Console.WriteLine("\t{0}", y.Title);
            }

        }

        //EJERCICIO4

        public void Ej4(string formato)
        {
            var consulta = movies.Where(n => n.Definition.Equals(formato)).Aggregate(0, (acc, s) => acc + s.Duration);
            Console.WriteLine(consulta);
        }


        //EJERCICIO5

        public void Ej5()
        {
            var consulta = movies.Join(genres, m => m.GenreID, g => g.GenreID,
                (m, g) => new
                {
                    Genero = g.GenreName,
                    Duracion = m.Duration
                }).GroupBy(g => g.Genero).Aggregate((acc, x) =>x.Count()> acc.Count() ? x:acc);

            Console.WriteLine(consulta.Key);
        }
    }
}
