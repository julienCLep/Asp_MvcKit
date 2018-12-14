using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Profilz.Models
{
    public class Repository<T> : DbSet<T> where T : Model
    {
        //trouver un élément
        public T Find (int? id)// int? donne la possibliter a l'id d'etre nullable
        {
            if (id.HasValue)//verifie si il y a une valeur dans l'id
            {
                return Local.FirstOrDefault(item =>item.Id == id); //retourne la valeur par defaut de l'id
            }

            return null;
        }
        

        /// <returns>//retrouve tous les éléments</returns>
        public List<T> FindAll()
        {
            return Local.ToList();
        }

        //methode permettent de retourner l'objet creer
        public override T Add(T source) //=> override car methode surcharger !!!
        {
            try
            {
                return base.Add(source);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update (T source)
            {
                T dbItem = Find(source.Id);

                 if (dbItem != null)
                 {
                    dbItem.UpdateFrom(source);
                    return true;
                 }
            return false;
            }


        public bool Remove(int? id)
        {
            if (id.HasValue)
            {
                T dbItem = Find(id);
                if (dbItem!=null)
                {
                    return Remove(dbItem);
                }
                return false;
            }
            return false;
        }
        public new bool Remove(T source)// new permet le changement du type de retour 
        {
            try
            {
                base.Remove(source);
                return true;
            }
            catch (Exception)
            {
              return false;
                
            }
        }
    }
}