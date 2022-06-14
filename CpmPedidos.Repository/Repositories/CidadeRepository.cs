﻿using CpmPedidos.Domain;
using CpmPedidos.Interface;
using CpmPedidos.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Repository
{
    public class CidadeRepository : BaseRepository, ICidadeRepository
    {
        public CidadeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public dynamic Get()
        {
            return DbContext.Cidades
                .Where(x => x.Ativo)
                .Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Uf,
                    x.Ativo
                })
                .ToList();
        }

        public int Criar(CidadeDTO model)
        {
            if(model.Id > 0)
            {
                return 0;
            }

            var nomeDuplicado = DbContext.Cidades.Any(x => x.Ativo && x.Nome.ToUpper() == model.Nome.ToUpper());
            
            if (nomeDuplicado)
            {
                return 0;
            }

            var entity = new Cidade()
            {
                Nome = model.Nome,
                Uf = model.Uf,
                Ativo = model.Ativo
            };

            try
            {
                DbContext.Cidades.Add(entity);
                DbContext.SaveChanges();
                return entity.Id;
            }
            catch (Exception ex )
            {
            }

            return 0;
        }

        public int Alterar(CidadeDTO model)
        {
            if(model.Id <= 0)
            {
                return 0;
            }

            var entity = DbContext.Cidades.Find(model.Id);
            if (entity == null)
            {
                return 0;
            }

            entity.Nome = model.Nome;
            entity.Uf = model.Uf;
            entity.Ativo = model.Ativo;

            try
            {
                DbContext.Cidades.Update(entity);
                DbContext.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
            }

            return 0;
        }
        public bool Excluir(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            var entity = DbContext.Cidades.Find(id);

            if (entity == null)
            {
                return false;
            }

            try
            {
                DbContext.Cidades.Remove(entity);
                DbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
            }

            return false;
        }
    }
}
