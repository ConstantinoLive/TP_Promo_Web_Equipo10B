﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categorias
    {
        public int Id { get; set; }

        public string Categoria { get; set;}

        public override string ToString()
        {
            return Categoria;
        }
    }
}
