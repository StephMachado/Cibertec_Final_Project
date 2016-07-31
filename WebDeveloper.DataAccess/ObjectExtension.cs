using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDeveloper.DataAccess
{
   public static class ObjectExtension
    {
        //Es una extensión
        public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        {
            //Take: Cantidad de registros que vamos a mostrar
            //Skip: Omite un número especificado de elementos de una secuencia y, 
            //a continuación, devuelve los elementos restantes.

            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }


    }
}
