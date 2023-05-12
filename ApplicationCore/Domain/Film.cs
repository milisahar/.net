using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public enum TypeFilm { Fiction, Action , Comedie ,Autre }
    public class Film
    {
        public int FilmId { get; set; }
        public string Titre { get; set; }
        public double Duree { get; set; }
        public DateTime DateRealisation { get; set; }
        public double Prix { get; set; }
        public TypeFilm TypeFilm { get; set; }
        public virtual ICollection<Projection> Projections { get; set; }

    }
}
