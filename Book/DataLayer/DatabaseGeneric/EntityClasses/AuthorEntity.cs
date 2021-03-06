//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.9.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using DL.HelperClasses;
using DL.FactoryClasses;
using DL.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace DL.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>Entity class which represents the entity 'Author'.<br/><br/></summary>
	[Serializable]
	public partial class AuthorEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<BookEntity> _books;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static AuthorEntityStaticMetaData _staticMetaData = new AuthorEntityStaticMetaData();
		private static AuthorRelations _relationsFactory = new AuthorRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Books</summary>
			public static readonly string Books = "Books";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class AuthorEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public AuthorEntityStaticMetaData()
			{
				SetEntityCoreInfo("AuthorEntity", InheritanceHierarchyType.None, false, (int)DL.EntityType.AuthorEntity, typeof(AuthorEntity), typeof(AuthorEntityFactory), false);
				AddNavigatorMetaData<AuthorEntity, EntityCollection<BookEntity>>("Books", a => a._books, (a, b) => a._books = b, a => a.Books, () => new AuthorRelations().BookEntityUsingAuthorId, typeof(BookEntity), (int)DL.EntityType.BookEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static AuthorEntity()
		{
		}

		/// <summary> CTor</summary>
		public AuthorEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AuthorEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AuthorEntity</param>
		public AuthorEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Author which data should be fetched into this Author object</param>
		public AuthorEntity(System.Int32 id) : this(id, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Author which data should be fetched into this Author object</param>
		/// <param name="validator">The custom validator object for this AuthorEntity</param>
		public AuthorEntity(System.Int32 id, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected AuthorEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Book' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooks() { return CreateRelationInfoForNavigator("Books"); }
		
		/// <inheritdoc/>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() {	return _staticMetaData; }

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{
			PerformDependencyInjection();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitClassMembersComplete();
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AuthorEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END


			OnInitialized();
		}

		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public static AuthorRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Book' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooks { get { return _staticMetaData.GetPrefetchPathElement("Books", CommonEntityBase.CreateEntityCollection<BookEntity>()); } }

		/// <summary>The Bio property of the Entity Author<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Authors"."Bio".<br/>Table field type characteristics (type, precision, scale, length): NChar, 0, 0, 250.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Bio
		{
			get { return (System.String)GetValue((int)AuthorFieldIndex.Bio, true); }
			set	{ SetValue((int)AuthorFieldIndex.Bio, value); }
		}

		/// <summary>The FirstName property of the Entity Author<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Authors"."FirstName".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)AuthorFieldIndex.FirstName, true); }
			set	{ SetValue((int)AuthorFieldIndex.FirstName, value); }
		}

		/// <summary>The Id property of the Entity Author<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Authors"."Id".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)AuthorFieldIndex.Id, true); }
			set { SetValue((int)AuthorFieldIndex.Id, value); }		}

		/// <summary>The LastName property of the Entity Author<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Authors"."LastName".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)AuthorFieldIndex.LastName, true); }
			set	{ SetValue((int)AuthorFieldIndex.LastName, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'BookEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(BookEntity))]
		public virtual EntityCollection<BookEntity> Books { get { return GetOrCreateEntityCollection<BookEntity, BookEntityFactory>("Author", true, false, ref _books); } }
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace DL
{
	public enum AuthorFieldIndex
	{
		///<summary>Bio. </summary>
		Bio,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>Id. </summary>
		Id,
		///<summary>LastName. </summary>
		LastName,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace DL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Author. </summary>
	public partial class AuthorRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between AuthorEntity and BookEntity over the 1:n relation they have, using the relation between the fields: Author.Id - Book.AuthorId</summary>
		public virtual IEntityRelation BookEntityUsingAuthorId
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "Books", true, new[] { AuthorFields.Id, BookFields.AuthorId }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticAuthorRelations
	{
		internal static readonly IEntityRelation BookEntityUsingAuthorIdStatic = new AuthorRelations().BookEntityUsingAuthorId;

		/// <summary>CTor</summary>
		static StaticAuthorRelations() { }
	}
}
