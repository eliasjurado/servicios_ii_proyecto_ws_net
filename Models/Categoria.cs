using System;
using System.Collections.Generic;

namespace techstore_ws.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdCategoria { get; set; }
        public string NomCategoria { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
