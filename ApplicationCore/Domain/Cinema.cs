using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class Cinema
    {
    public int CinemaId { get; set; }
        public string Nom { get; set; }
        public string Localisation { get; set; }
        public virtual ICollection<Salle> Salles { get; set; }
    }
}
