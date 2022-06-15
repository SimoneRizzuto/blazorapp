﻿//////////////////////////////////////////////////////////////
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

	/// <summary>Entity class which represents the entity 'Book'.<br/><br/></summary>
	[Serializable]
	public partial class BookEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private AuthorEntity _author;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static BookEntityStaticMetaData _staticMetaData = new BookEntityStaticMetaData();
		private static BookRelations _relationsFactory = new BookRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Author</summary>
			public static readonly string Author = "Author";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class BookEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public BookEntityStaticMetaData()
			{
				SetEntityCoreInfo("BookEntity", InheritanceHierarchyType.None, false, (int)DL.EntityType.BookEntity, typeof(BookEntity), typeof(BookEntityFactory), false);
				AddNavigatorMetaData<BookEntity, AuthorEntity>("Author", "Books", (a, b) => a._author = b, a => a._author, (a, b) => a.Author = b, DL.RelationClasses.StaticBookRelations.AuthorEntityUsingAuthorIdStatic, ()=>new BookRelations().AuthorEntityUsingAuthorId, null, new int[] { (int)BookFieldIndex.AuthorId }, null, true, (int)DL.EntityType.AuthorEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static BookEntity()
		{
		}

		/// <summary> CTor</summary>
		public BookEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public BookEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this BookEntity</param>
		public BookEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Book which data should be fetched into this Book object</param>
		public BookEntity(System.Int32 id) : this(id, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Book which data should be fetched into this Book object</param>
		/// <param name="validator">The custom validator object for this BookEntity</param>
		public BookEntity(System.Int32 id, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected BookEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Author' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAuthor() { return CreateRelationInfoForNavigator("Author"); }
		
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
		/// <param name="validator">The validator object for this BookEntity</param>
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
		public static BookRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Author' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAuthor { get { return _staticMetaData.GetPrefetchPathElement("Author", CommonEntityBase.CreateEntityCollection<AuthorEntity>()); } }

		/// <summary>The AuthorId property of the Entity Book<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Books"."AuthorId".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> AuthorId
		{
			get { return (Nullable<System.Int32>)GetValue((int)BookFieldIndex.AuthorId, false); }
			set	{ SetValue((int)BookFieldIndex.AuthorId, value); }
		}

		/// <summary>The Id property of the Entity Book<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Books"."Id".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)BookFieldIndex.Id, true); }
			set { SetValue((int)BookFieldIndex.Id, value); }		}

		/// <summary>The Image property of the Entity Book<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Books"."Image".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Image
		{
			get { return (System.String)GetValue((int)BookFieldIndex.Image, true); }
			set	{ SetValue((int)BookFieldIndex.Image, value); }
		}

		/// <summary>The Isbn property of the Entity Book<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Books"."ISBN".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Isbn
		{
			get { return (System.String)GetValue((int)BookFieldIndex.Isbn, true); }
			set	{ SetValue((int)BookFieldIndex.Isbn, value); }
		}

		/// <summary>The Price property of the Entity Book<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Books"."Price".<br/>Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Price
		{
			get { return (Nullable<System.Decimal>)GetValue((int)BookFieldIndex.Price, false); }
			set	{ SetValue((int)BookFieldIndex.Price, value); }
		}

		/// <summary>The Summary property of the Entity Book<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Books"."Summary".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Summary
		{
			get { return (System.String)GetValue((int)BookFieldIndex.Summary, true); }
			set	{ SetValue((int)BookFieldIndex.Summary, value); }
		}

		/// <summary>The Title property of the Entity Book<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Books"."Title".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Title
		{
			get { return (System.String)GetValue((int)BookFieldIndex.Title, true); }
			set	{ SetValue((int)BookFieldIndex.Title, value); }
		}

		/// <summary>The Year property of the Entity Book<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Books"."Year".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> Year
		{
			get { return (Nullable<System.Int32>)GetValue((int)BookFieldIndex.Year, false); }
			set	{ SetValue((int)BookFieldIndex.Year, value); }
		}

		/// <summary>Gets / sets related entity of type 'AuthorEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual AuthorEntity Author
		{
			get { return _author; }
			set { SetSingleRelatedEntityNavigator(value, "Author"); }
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace DL
{
	public enum BookFieldIndex
	{
		///<summary>AuthorId. </summary>
		AuthorId,
		///<summary>Id. </summary>
		Id,
		///<summary>Image. </summary>
		Image,
		///<summary>Isbn. </summary>
		Isbn,
		///<summary>Price. </summary>
		Price,
		///<summary>Summary. </summary>
		Summary,
		///<summary>Title. </summary>
		Title,
		///<summary>Year. </summary>
		Year,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace DL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Book. </summary>
	public partial class BookRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between BookEntity and AuthorEntity over the m:1 relation they have, using the relation between the fields: Book.AuthorId - Author.Id</summary>
		public virtual IEntityRelation AuthorEntityUsingAuthorId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Author", false, new[] { AuthorFields.Id, BookFields.AuthorId }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticBookRelations
	{
		internal static readonly IEntityRelation AuthorEntityUsingAuthorIdStatic = new BookRelations().AuthorEntityUsingAuthorId;

		/// <summary>CTor</summary>
		static StaticBookRelations() { }
	}
}
