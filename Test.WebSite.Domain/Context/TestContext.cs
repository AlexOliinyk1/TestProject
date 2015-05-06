﻿using System;
using System.Data.Entity;
using System.Linq;
using Test.WebSite.Domain.Common;
using Test.WebSite.Domain.EntityModel;

namespace Test.WebSite.Domain.Context
{
    public class TestContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestContext"/> class.
        /// </summary>
        public TestContext()
            : base("Name=TestContext")
        {
        }

        /// <summary>
        /// Gets or sets the purchase orders.
        /// </summary>
        /// <value>
        /// The purchase orders.
        /// </value>
        public DbSet<Album> Albums { get; set; }


        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are created for
        /// many-to-many relationships and relationships where there is no foreign key property
        /// included in the entity class (often referred to as independent associations).
        /// </returns>
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as IEntity;
                if (entity != null)
                {
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
