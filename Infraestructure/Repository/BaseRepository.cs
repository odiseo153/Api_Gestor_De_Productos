using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Domain.Interfaces;
using Gestor_Productos.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_Productos.Infraestructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private ApplicationContext context;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Esta funcion se usa para crear una entidad y guardarla en la base de datos
        /// </summary>
        /// <returns></returns>
        public async Task<T> Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return  entity ;

        }

        /// <summary>
        /// Esta funcion se usa para eliminar una entidad por su Id
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Delete(string Id)
        {
            var entity =await context.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(Id));

            if (entity == null)
            {
                return false;
            }

            context.Remove(entity);
            await context.SaveChangesAsync();

            return true;

        }
        /// <summary>
        /// Esta funcion se usa para traer todas las entidades,recibiendo como parametro conditions
        /// </summary>
        /// <returns>
        /// Devuelve todas las entidades
        /// </returns>
        public async Task<List<T>> GetAll( Func<T, bool> conditions = null)
        {
            var entity = context.Set<T>().ToList();

            if (conditions != null)
            {
                entity.Where(conditions);
            }

            return entity == null ? new List<T>() : entity;
        }


        public async Task<T> GetById(string Id)
        {
            var entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(Id));


            return entity == null ? null : entity;

        }

        public async Task<bool> Update(BaseEntity entity)
        {
            try
            {
                var entida = await context.Set<T>().FindAsync(entity.Id);

                foreach (var propiedad in entity.GetType().GetProperties())
                {
                    var valorEntidad = propiedad.GetValue(entity);
                    var valorFinal = valorEntidad ?? propiedad.GetValue(entida);

                    propiedad.SetValue(entida, valorFinal);
                }

                await context.SaveChangesAsync();

                return true;
            }catch  
            {
              return false;
            }
        }
    }
}
