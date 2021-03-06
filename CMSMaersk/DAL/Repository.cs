﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMSMaersk.DAL
{
    public class Repository<T> where T : class
    {
        private ContainerContext context = new ContainerContext();

        protected DbSet<T> DbSet { get; set; }

        public Repository()
        {
            DbSet = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T Get(int i)
        {
            return DbSet.Find(i);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}