﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.9.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using DL.EntityClasses;
using DL.HelperClasses;
using DL.RelationClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace DL.FactoryClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END


	/// <summary>general base class for the generated factories</summary>
	[Serializable]
	public partial class EntityFactoryBase2<TEntity> : EntityFactoryCore2
		where TEntity : EntityBase2, IEntity2
	{
		private readonly bool _isInHierarchy;

		/// <summary>CTor</summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <param name="isInHierarchy">If true, the entity of this factory is in an inheritance hierarchy, false otherwise</param>
		public EntityFactoryBase2(string entityName, DL.EntityType typeOfEntity, bool isInHierarchy) : base(entityName, (int)typeOfEntity)
		{
			_isInHierarchy = isInHierarchy;
		}
		
		/// <inheritdoc/>
		public override IEntityFields2 CreateFields() { return ModelInfoProviderSingleton.GetInstance().GetEntityFields(this.ForEntityName); }
		
		/// <inheritdoc/>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue) {	return GeneralEntityFactory.Create((DL.EntityType)entityTypeValue); }

		/// <inheritdoc/>
		public override IRelationCollection CreateHierarchyRelations(string objectAlias) { return ModelInfoProviderSingleton.GetInstance().GetHierarchyRelations(this.ForEntityName, objectAlias); }

		/// <inheritdoc/>
		public override IEntityFactory2 GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity) 
		{
			return (IEntityFactory2)ModelInfoProviderSingleton.GetInstance().GetEntityFactory(this.ForEntityName, fieldValues, entityFieldStartIndexesPerEntity) ?? this;
		}
		
		/// <inheritdoc/>
		public override IPredicateExpression GetEntityTypeFilter(bool negate, string objectAlias) {	return ModelInfoProviderSingleton.GetInstance().GetEntityTypeFilter(this.ForEntityName, objectAlias, negate);	}
						
		/// <inheritdoc/>
		public override IEntityCollection2 CreateEntityCollection()	{ return new EntityCollection<TEntity>(this); }
		
		/// <inheritdoc/>
		public override IEntityFields2 CreateHierarchyFields() 
		{
			return _isInHierarchy ? new EntityFields2(ModelInfoProviderSingleton.GetInstance().GetHierarchyFields(this.ForEntityName), ModelInfoProviderSingleton.GetInstance(), null) : base.CreateHierarchyFields();
		}
		
		/// <inheritdoc/>
		protected override Type ForEntityType { get { return typeof(TEntity); } }
	}

	/// <summary>Factory to create new, empty AspNetRoleEntity objects.</summary>
	[Serializable]
	public partial class AspNetRoleEntityFactory : EntityFactoryBase2<AspNetRoleEntity> 
	{
		/// <summary>CTor</summary>
		public AspNetRoleEntityFactory() : base("AspNetRoleEntity", DL.EntityType.AspNetRoleEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AspNetRoleEntity(fields); }
	}

	/// <summary>Factory to create new, empty AspNetRoleClaimEntity objects.</summary>
	[Serializable]
	public partial class AspNetRoleClaimEntityFactory : EntityFactoryBase2<AspNetRoleClaimEntity> 
	{
		/// <summary>CTor</summary>
		public AspNetRoleClaimEntityFactory() : base("AspNetRoleClaimEntity", DL.EntityType.AspNetRoleClaimEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AspNetRoleClaimEntity(fields); }
	}

	/// <summary>Factory to create new, empty AspNetUserEntity objects.</summary>
	[Serializable]
	public partial class AspNetUserEntityFactory : EntityFactoryBase2<AspNetUserEntity> 
	{
		/// <summary>CTor</summary>
		public AspNetUserEntityFactory() : base("AspNetUserEntity", DL.EntityType.AspNetUserEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AspNetUserEntity(fields); }
	}

	/// <summary>Factory to create new, empty AspNetUserClaimEntity objects.</summary>
	[Serializable]
	public partial class AspNetUserClaimEntityFactory : EntityFactoryBase2<AspNetUserClaimEntity> 
	{
		/// <summary>CTor</summary>
		public AspNetUserClaimEntityFactory() : base("AspNetUserClaimEntity", DL.EntityType.AspNetUserClaimEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AspNetUserClaimEntity(fields); }
	}

	/// <summary>Factory to create new, empty AspNetUserLoginEntity objects.</summary>
	[Serializable]
	public partial class AspNetUserLoginEntityFactory : EntityFactoryBase2<AspNetUserLoginEntity> 
	{
		/// <summary>CTor</summary>
		public AspNetUserLoginEntityFactory() : base("AspNetUserLoginEntity", DL.EntityType.AspNetUserLoginEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AspNetUserLoginEntity(fields); }
	}

	/// <summary>Factory to create new, empty AspNetUserRoleEntity objects.</summary>
	[Serializable]
	public partial class AspNetUserRoleEntityFactory : EntityFactoryBase2<AspNetUserRoleEntity> 
	{
		/// <summary>CTor</summary>
		public AspNetUserRoleEntityFactory() : base("AspNetUserRoleEntity", DL.EntityType.AspNetUserRoleEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AspNetUserRoleEntity(fields); }
	}

	/// <summary>Factory to create new, empty AspNetUserTokenEntity objects.</summary>
	[Serializable]
	public partial class AspNetUserTokenEntityFactory : EntityFactoryBase2<AspNetUserTokenEntity> 
	{
		/// <summary>CTor</summary>
		public AspNetUserTokenEntityFactory() : base("AspNetUserTokenEntity", DL.EntityType.AspNetUserTokenEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AspNetUserTokenEntity(fields); }
	}

	/// <summary>Factory to create new, empty AuthorEntity objects.</summary>
	[Serializable]
	public partial class AuthorEntityFactory : EntityFactoryBase2<AuthorEntity> 
	{
		/// <summary>CTor</summary>
		public AuthorEntityFactory() : base("AuthorEntity", DL.EntityType.AuthorEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AuthorEntity(fields); }
	}

	/// <summary>Factory to create new, empty BookEntity objects.</summary>
	[Serializable]
	public partial class BookEntityFactory : EntityFactoryBase2<BookEntity> 
	{
		/// <summary>CTor</summary>
		public BookEntityFactory() : base("BookEntity", DL.EntityType.BookEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new BookEntity(fields); }
	}

	/// <summary>Factory to create new, empty EfmigrationsHistoryEntity objects.</summary>
	[Serializable]
	public partial class EfmigrationsHistoryEntityFactory : EntityFactoryBase2<EfmigrationsHistoryEntity> 
	{
		/// <summary>CTor</summary>
		public EfmigrationsHistoryEntityFactory() : base("EfmigrationsHistoryEntity", DL.EntityType.EfmigrationsHistoryEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new EfmigrationsHistoryEntity(fields); }
	}

	/// <summary>Factory to create new, empty Entity objects based on the entity type specified. Uses  entity specific factory objects</summary>
	[Serializable]
	public partial class GeneralEntityFactory
	{
		/// <summary>Creates a new, empty Entity object of the type specified</summary>
		/// <param name="entityTypeToCreate">The entity type to create.</param>
		/// <returns>A new, empty Entity object.</returns>
		public static IEntity2 Create(DL.EntityType entityTypeToCreate)
		{
			var factoryToUse = EntityFactoryFactory.GetFactory(entityTypeToCreate);
			IEntity2 toReturn = null;
			if(factoryToUse != null)
			{
				toReturn = factoryToUse.Create();
			}
			return toReturn;
		}		
	}
		
	/// <summary>Class which is used to obtain the entity factory based on the .NET type of the entity. </summary>
	[Serializable]
	public static class EntityFactoryFactory
	{
		private static Dictionary<Type, IEntityFactory2> _factoryPerType = new Dictionary<Type, IEntityFactory2>();

		/// <summary>Initializes the <see cref="EntityFactoryFactory"/> class.</summary>
		static EntityFactoryFactory()
		{
			foreach(int entityTypeValue in Enum.GetValues(typeof(DL.EntityType)))
			{
				var factory = GetFactory((DL.EntityType)entityTypeValue);
				_factoryPerType.Add(factory.ForEntityType ?? factory.Create().GetType(), factory);
			}
		}

		/// <summary>Gets the factory of the entity with the .NET type specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(Type typeOfEntity) { return _factoryPerType.GetValue(typeOfEntity); }

		/// <summary>Gets the factory of the entity with the DL.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(DL.EntityType typeOfEntity)
		{
			switch(typeOfEntity)
			{
				case DL.EntityType.AspNetRoleEntity:
					return new AspNetRoleEntityFactory();
				case DL.EntityType.AspNetRoleClaimEntity:
					return new AspNetRoleClaimEntityFactory();
				case DL.EntityType.AspNetUserEntity:
					return new AspNetUserEntityFactory();
				case DL.EntityType.AspNetUserClaimEntity:
					return new AspNetUserClaimEntityFactory();
				case DL.EntityType.AspNetUserLoginEntity:
					return new AspNetUserLoginEntityFactory();
				case DL.EntityType.AspNetUserRoleEntity:
					return new AspNetUserRoleEntityFactory();
				case DL.EntityType.AspNetUserTokenEntity:
					return new AspNetUserTokenEntityFactory();
				case DL.EntityType.AuthorEntity:
					return new AuthorEntityFactory();
				case DL.EntityType.BookEntity:
					return new BookEntityFactory();
				case DL.EntityType.EfmigrationsHistoryEntity:
					return new EfmigrationsHistoryEntityFactory();
				default:
					return null;
			}
		}
	}
		
	/// <summary>Element creator for creating project elements from somewhere else, like inside Linq providers.</summary>
	public class ElementCreator : ElementCreatorBase, IElementCreator2
	{
		/// <summary>Gets the factory of the Entity type with the DL.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(int entityTypeValue) { return (IEntityFactory2)this.GetFactoryImpl(entityTypeValue); }
		
		/// <summary>Gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(Type typeOfEntity) { return (IEntityFactory2)this.GetFactoryImpl(typeOfEntity); }

		/// <summary>Creates a new resultset fields object with the number of field slots reserved as specified</summary>
		/// <param name="numberOfFields">The number of fields.</param>
		/// <returns>ready to use resultsetfields object</returns>
		public IEntityFields2 CreateResultsetFields(int numberOfFields) { return new ResultsetFields(numberOfFields); }
		
		/// <inheritdoc/>
		public override IInheritanceInfoProvider ObtainInheritanceInfoProviderInstance() { return ModelInfoProviderSingleton.GetInstance(); }

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand) { return new DynamicRelation(leftOperand); }

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(IEntityFieldCore leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, string aliasLeftOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, aliasLeftOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (DL.EntityType)Enum.Parse(typeof(DL.EntityType), rightOperandEntityName, false), aliasRightOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(string leftOperandEntityName, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation((DL.EntityType)Enum.Parse(typeof(DL.EntityType), leftOperandEntityName, false), joinType, (DL.EntityType)Enum.Parse(typeof(DL.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(IEntityFieldCore leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (DL.EntityType)Enum.Parse(typeof(DL.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <inheritdoc/>
		protected override IEntityFactoryCore GetFactoryImpl(int entityTypeValue) { return EntityFactoryFactory.GetFactory((DL.EntityType)entityTypeValue); }

		/// <inheritdoc/>
		protected override IEntityFactoryCore GetFactoryImpl(Type typeOfEntity) { return EntityFactoryFactory.GetFactory(typeOfEntity);	}

	}
}
