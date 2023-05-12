using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public  class Projection
    {
        public DateTime DateProjection { get; set; }
        public string TypeProjection { get; set; }

        public virtual Salle MySalle { get; set; }
        public virtual Film MyFilm { get; set; }
        public int FilmFk { get; set; }
        public int SalleFk { get; set; }
    }
}
