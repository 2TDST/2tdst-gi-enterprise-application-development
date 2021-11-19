using System.Collections.Generic;
using WebApplicationForChallenge.Models;

namespace WebApplicationForChallenge.ViewModels
{
    public class OngViewModels
    {
        public IList<Ong> Lista { get; set; }
        public string NomeBusca { get; set; }
        public Porte? PorteBusca { get; set; }
    }
}
