using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //public partial class Repository2<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    //{
    //    public DbContext context;
    //    public DbSet<TEntity> dbSet;

    //    public Repository2(DbContext DbContext)
    //    {
    //        this.context = DbContext;
    //        this.dbSet = context.Set<TEntity>();
    //    }
    //    public IQueryable<TEntity> GetAll()
    //    {
    //        return dbSet.AsQueryable();
    //    }





    //    public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions)
    //    {
    //        IQueryable<TEntity> set = dbSet.AsQueryable();

    //        foreach (var includeExpression in includeExpressions)
    //        {
    //            set = set.Include(includeExpression);
    //        }
    //        return set;
    //    }

    //    public TEntity GetById(int Id)
    //    {
    //        return Single(x => x.Id == Id);
    //    }

    //    public virtual void Create(TEntity entity)
    //    {
    //        dbSet.Add(entity);

    //    }

    //    public virtual void Update(int EntityId, string Property, string Value, bool updateNulls = false)
    //    {
    //        throw new NotImplementedException("Luke to refactor with Tiago");
    //        ////establish whether property being updated is a relationship
    //        //var objectContext = ((IObjectContextAdapter)context).ObjectContext;
    //        //var set = objectContext.CreateObjectSet<TEntity>();
    //        //bool isRelationship = set.EntitySet.ElementType.NavigationProperties.Where(x => x.Name == Property).Any();
    //        //bool isMapped = set.EntitySet.ElementType.Properties.Where(x => x.Name == Property).Any();

    //        ////if a property isn't mapped, brute force set using reflection
    //        //if (!isMapped)
    //        //{
    //        //    var propertyType = typeof(TEntity).GetProperty(Property).PropertyType;
    //        //    var underlyingType = Nullable.GetUnderlyingType(propertyType);
    //        //    var cValue = Convert.ChangeType(Value, underlyingType ?? propertyType);
    //        //    typeof(TEntity).GetProperty(Property).SetValue(GetById(EntityId),cValue);
    //        //}


    //        //if (EntityId > 0 && Value != null && !isRelationship && isMapped)
    //        //{
    //        //    //update property if not a relationship
    //        //    var attachedEntity = GetById(EntityId);
    //        //    var entry = context.Entry(attachedEntity);

    //        //    if (!isRelationship)
    //        //    {
    //        //        // Get the type of the property
    //        //        Type propType = typeof(TEntity).GetProperty(Property).PropertyType;
    //        //        entry.Property(Property).IsModified = true;
    //        //        // Get the value based on the property type
    //        //        entry.Property(Property).CurrentValue = GetPropertyValue(propType, Value);
    //        //    }
    //        //    else
    //        //    {
    //        //        var dKey = (dynamic)Value;
    //        //        if (dKey.Id != null) //so long as the relationship object has an Id we can update
    //        //        {
    //        //            entry.Reference(Property).CurrentValue = Value;
    //        //        }
    //        //    }

    //        //}
    //    }

    //    public virtual void Update(TEntity entity, bool updateNulls = false)
    //    {
    //        try
    //        {
    //            var entry = context.Entry(entity);
    //            if (entry.State == EntityState.Detached)
    //            {
    //                var attachedEntity = GetById(entry.Entity.Id);
    //                if (attachedEntity != null)
    //                {
    //                    var attachedEntry = context.Entry(attachedEntity);
    //                    attachedEntry.CurrentValues.SetValues(entity);
    //                    //exclude nulls
    //                    foreach (var prop in attachedEntry.OriginalValues.PropertyNames)
    //                    {
    //                        //only update nulls if explicitly told to
    //                        //TODO: Replace 'entry.Property(prop).Name.Substring(entry.Property(prop).Name.Length - 2).Equals("ID"))'
    //                        // by checking if the property is foreign key
    //                        if (((entry.Property(prop).CurrentValue == null || entry.Property(prop).CurrentValue.Equals("scnull")) && !updateNulls)
    //                            || (Convert.ToString(entry.Property(prop).CurrentValue) == "0" && entry.Property(prop).Name.Substring(entry.Property(prop).Name.Length - 2).Equals("Id")))
    //                        {
    //                            attachedEntry.Property(prop).CurrentValue = attachedEntry.Property(prop).OriginalValue;
    //                            attachedEntry.Property(prop).IsModified = false;
    //                        }
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                dbSet.Attach(entity);
    //                entry.State = EntityState.Modified;
    //            }
    //        }

    //        catch (OptimisticConcurrencyException ex)
    //        {
    //            //TODO: Add injectable exception handling module
    //            Logger.WriteException(ex, string.Format("'Update' had a problem: {0}. entity Name:{1}", ex.Message, entity.GetType().Name));
    //            throw;
    //        }
    //    }

    //    public virtual TEntity UpdateRelationship<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyMapping) where TProperty : class, IEntity
    //    {
    //        throw new NotImplementedException("Luke to refactor with Tiago");
    //        //try
    //        //{

    //        //    var entry = context.Entry(entity);
    //        //    var attachedEntity = GetById(entity.Id);
    //        //    var propertyRepository = new Repository<TProperty>(context);
    //        //    //TODO: find a way to do this without going back to db using stub object
    //        //    var stub = propertyMapping.Compile().Invoke(entity);
    //        //    //first try to load relationship from db for provided entity
    //        //    if (stub != null)
    //        //    {
    //        //        if (stub.Id > 0)
    //        //        {
    //        //            var dbEntity = propertyRepository.GetById(stub.Id);

    //        //            if (dbEntity != null)
    //        //            {
    //        //                var propertyExpression = propertyMapping.Body as MemberExpression;
    //        //                var propertyInfo = propertyExpression.Member as PropertyInfo;
    //        //                propertyInfo.SetValue(entity, dbEntity);
    //        //            }


    //        //            if (attachedEntity != null)
    //        //            {
    //        //                var attachedEntry = context.Entry(attachedEntity);
    //        //                attachedEntry.Reference(propertyMapping).CurrentValue = dbEntity;
    //        //            }
    //        //        }
    //        //        else if (stub.Id == 0)
    //        //        {
    //        //            var propertyExpression = propertyMapping.Body as MemberExpression;
    //        //            var propertyInfo = propertyExpression.Member as PropertyInfo;
    //        //            propertyInfo.SetValue(entity, stub);

    //        //            if (attachedEntity != null)
    //        //            {
    //        //                var attachedEntry = context.Entry(attachedEntity);
    //        //                attachedEntry.Reference(propertyMapping).CurrentValue = stub;
    //        //            }
    //        //        }
    //        //    }
    //        //    //try to get the relationship from the already attached entity should the provided relationship be null
    //        //    else
    //        //    {
    //        //        if (attachedEntity != null)
    //        //        {
    //        //            var propertyExpression = propertyMapping.Body as MemberExpression;
    //        //            var propertyInfo = propertyExpression.Member as PropertyInfo;
    //        //            propertyInfo.SetValue(entity, propertyMapping.Compile().Invoke(attachedEntity));
    //        //        }
    //        //    }
    //        //    return entity;
    //        //}

    //        //catch (OptimisticConcurrencyException ex)
    //        //{
    //        //    throw;
    //        //}
    //    }



    //    public virtual void Delete(TEntity entity)
    //    {
    //        dbSet.Remove(entity);
    //    }

    //    public virtual void Delete(int Id)
    //    {
    //        Delete(GetById(Id));
    //    }

    //    public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
    //    {

    //        IQueryable<TEntity> query = dbSet.Where(predicate).AsQueryable();
    //        foreach (TEntity obj in query)
    //        {
    //            dbSet.Remove(obj);
    //        }
    //    }

    //    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> criteria)
    //    {
    //        return GetAll().Where(criteria);
    //    }

    //    public TEntity Single(Expression<Func<TEntity, bool>> criteria)
    //    {
    //        return Find(criteria).FirstOrDefault();
    //    }

    //    #region private methods
    //    private object GetPropertyValue(Type type, string value, bool isNullable = false)
    //    {
    //        if (isNullable && string.IsNullOrEmpty(value))
    //        {
    //            return null;
    //        }
    //        else
    //        {
    //            // Determine the type of the property
    //            switch (Type.GetTypeCode(type))
    //            {
    //                case TypeCode.String:
    //                    return value;

    //                case TypeCode.Int32:
    //                    int valueInt;
    //                    int.TryParse(value, out valueInt);
    //                    return valueInt;

    //                case TypeCode.Decimal:
    //                    decimal valueDecimal;
    //                    decimal.TryParse(value, out valueDecimal);
    //                    return valueDecimal;

    //                case TypeCode.DateTime:
    //                    DateTime valueDateTime;
    //                    DateTime.TryParse(value, out valueDateTime);
    //                    return valueDateTime;

    //                case TypeCode.Boolean:
    //                    bool valueBool;
    //                    bool.TryParse(value, out valueBool);
    //                    return valueBool;

    //                case TypeCode.Object:
    //                    // Check for nullable type
    //                    Type underlyingType = Nullable.GetUnderlyingType(type);
    //                    if (underlyingType != null)
    //                    {
    //                        // Type is nullable
    //                        return GetPropertyValue(underlyingType, value, true);
    //                    }
    //                    else
    //                    {
    //                        return Convert.ChangeType(value, type);
    //                    }

    //                default:
    //                    return Convert.ChangeType(value, type);
    //            }
    //        }
    //    }
    //    #endregion
    //}
}
