// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TreeCollection.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Text;
using System.Xml;
using System.IO;

namespace Zeroit.Framework.Utilities.Collections.Generic
{
    /// <summary>
    /// Incomplete class, not use.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeCollection<T>
	{
        /// <summary>
        /// Delegate TreeItemEnumDelegate
        /// </summary>
        /// <param name="current">The current.</param>
        public delegate void TreeItemEnumDelegate(TreeItem<T> current);
        /// <summary>
        /// Delegate TreeItemXmlWriterDelegate
        /// </summary>
        /// <param name="current">The current.</param>
        /// <param name="writer">The writer.</param>
        public delegate void TreeItemXmlWriterDelegate(TreeItem<T> current, XmlTextWriter writer);
        /// <summary>
        /// Delegate TreeItemStringWriterDelegate
        /// </summary>
        /// <param name="current">The current.</param>
        /// <param name="builder">The builder.</param>
        public delegate void TreeItemStringWriterDelegate(TreeItem<T> current, StringBuilder builder);
        /// <summary>
        /// Delegate TreeItemXmlReaderDelegate
        /// </summary>
        /// <param name="current">The current.</param>
        /// <param name="currentNode">The current node.</param>
        public delegate void TreeItemXmlReaderDelegate(ref TreeItem<T> current, XmlNode currentNode);

        /// <summary>
        /// The global collection
        /// </summary>
        private KeyedCollection<TreeItem<T>> _globalCollection;
        /// <summary>
        /// The global values
        /// </summary>
        private KeyedCollection<T> _globalValues;
        /// <summary>
        /// The root items
        /// </summary>
        private LightCollection<string> _rootItems;

        /// <summary>
        /// Gets the global collection.
        /// </summary>
        /// <value>The global collection.</value>
        internal KeyedCollection<TreeItem<T>> GlobalCollection
		{
			get
			{
				return _globalCollection;
			}
		}
        /// <summary>
        /// Gets the global values.
        /// </summary>
        /// <value>The global values.</value>
        internal KeyedCollection<T> GlobalValues
		{
			get
			{
				return _globalValues;
			}
		}

        /// <summary>
        /// Globals the add item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal bool Global_AddItem(string id, TreeItem<T> item)
		{
			if (_globalCollection.ContainsKey(id)) return false;

			_globalCollection.Add(id, item);
			_globalValues.Add(id, default(T));
			return true;
		}
        /// <summary>
        /// Globals the remove item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal bool Global_RemoveItem(string id)
		{
			if (_globalCollection.ContainsKey(id)) return false;

			_globalCollection.RemoveByKey(id);
			_globalValues.RemoveByKey(id);
			return true;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeCollection{T}"/> class.
        /// </summary>
        public TreeCollection():this(32)
		{
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeCollection{T}"/> class.
        /// </summary>
        /// <param name="initialSize">The initial size.</param>
        public TreeCollection(int initialSize)
		{
			_globalCollection = new KeyedCollection<TreeItem<T>>(initialSize);
			_globalValues = new KeyedCollection<T>(initialSize);
			_rootItems = new LightCollection<string>();
		}

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public TreeItemCollection<T> Items
		{
			get 
			{
				TreeCollection<T> _this = this;
				return new TreeItemCollection<T>(ref _this, "_root", _rootItems); 
			}
		}
        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <value>All items.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        public KeyedCollection<T> AllItems
		{
			get 
			{
				throw new NotImplementedException();
			}
		}

        /*public void AddRootItem(T value)
		{
			string key = _globalCollection.CreateFreeKey();
			AddRootItem(key, value);
		}
		public void AddRootItem(string id)
		{
			AddRootItem(id, default(T));
		}
		public void AddRootItem(string id, T value)
		{
			if(_globalCollection.Contains(id))
				throw new Exception("key \""+id+"\" already exist");

			TreeCollection<T> _this = this;
			TreeItem<T> treeItem = new TreeItem<T>(id, "_root", ref _this);
			_globalCollection.Add(id, treeItem);
			_globalCollection[id].Value = value;

			_rootItems.Add(id);

		}
		public bool TryAddRootItem(string id, T value)
		{
			if(_globalCollection.Contains(id))
			{
				return false;
			}

			TreeCollection<T> _this = this;
			TreeItem<T> treeItem = new TreeItem<T>(id, "_root", ref _this);
			_globalCollection.Add(id, treeItem);
			_globalCollection[id].Value = value;

			_rootItems.Add(id);
			return true;
		}*/

        /// <summary>
        /// Enumerates the subitems.
        /// </summary>
        /// <param name="itemsEnum">The items enum.</param>
        public void EnumerateSubitems(TreeItemEnumDelegate itemsEnum)
		{
			EnumerateSubitems(itemsEnum, null);
		}
        /// <summary>
        /// Enumerates the subitems.
        /// </summary>
        /// <param name="itemsEnum">The items enum.</param>
        /// <param name="startItem">The start item.</param>
        public void EnumerateSubitems(TreeItemEnumDelegate itemsEnum, TreeItem<T> startItem)
		{
			LightCollection<string> subitems;
			if (startItem == null)
			{
				subitems = _rootItems;
			}
			else
			{
				subitems = startItem.Subitems.ItemsId;
			}

			for (int i = 0; i < subitems.Count; i++)
			{
				if (itemsEnum != null)
				{
					TreeItem<T> current = _globalCollection[subitems[i]];
					itemsEnum(current);
					EnumerateSubitems(itemsEnum, current);
				}
			}
		}

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>TreeItemEnumerator&lt;T&gt;.</returns>
        public TreeItemEnumerator<T> GetEnumerator()
		{
			return new TreeItemEnumerator<T>(ref _globalCollection, _rootItems);
		}

        /// <summary>
        /// Froms the XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="readerDelegate">The reader delegate.</param>
        /// <returns>TreeCollection&lt;T&gt;.</returns>
        public static TreeCollection<T> FromXml(string xml, TreeItemXmlReaderDelegate readerDelegate)
		{
			XmlDocument xdoc = new XmlDocument();
			xdoc.LoadXml(xml);
			return FromXml(xdoc, readerDelegate);
		}
        /// <summary>
        /// Froms the XML.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="readerDelegate">The reader delegate.</param>
        /// <returns>TreeCollection&lt;T&gt;.</returns>
        public static TreeCollection<T> FromXml(Stream stream, TreeItemXmlReaderDelegate readerDelegate)
		{
			XmlDocument xdoc = new XmlDocument();
			xdoc.Load(stream);
			return FromXml(xdoc, readerDelegate);
		}
        /// <summary>
        /// Froms the XML.
        /// </summary>
        /// <param name="xdoc">The xdoc.</param>
        /// <param name="readerDelegate">The reader delegate.</param>
        /// <returns>TreeCollection&lt;T&gt;.</returns>
        public static TreeCollection<T> FromXml(XmlDocument xdoc, TreeItemXmlReaderDelegate readerDelegate)
		{
			XmlNodeList xlist = xdoc.SelectNodes("TreeCollection//TreeItem");
			TreeCollection<T> treeColl = new TreeCollection<T>(xlist.Count);

			xlist = xdoc.SelectNodes("TreeCollection/TreeItem");

			for (int i = 0; i < xlist.Count; i++)
			{
				XmlNode currentNode = xlist[i];

				TreeItem<T> newItem = treeColl.Items.Add(treeColl.GlobalCollection.CreateFreeKey(), default(T));

				readerDelegate(ref newItem, currentNode);

				if (currentNode.ChildNodes.Count > 0)
				{
					TreeItemCollection<T> currentColl = treeColl.Items;
					FromXmlNode(treeColl, ref currentColl, xlist[i], readerDelegate);
				}
			}
			return treeColl;
		}
        /// <summary>
        /// Froms the XML by reflection.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>TreeCollection&lt;T&gt;.</returns>
        public static TreeCollection<T> FromXmlByReflection(string xml)
		{
			XmlDocument xdoc = new XmlDocument();
			xdoc.LoadXml(xml);
			return FromXmlByReflection(xdoc);
		}
        /// <summary>
        /// Froms the XML by reflection.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>TreeCollection&lt;T&gt;.</returns>
        public static TreeCollection<T> FromXmlByReflection(Stream stream)
		{
			XmlDocument xdoc = new XmlDocument();
			xdoc.Load(stream);
			return FromXmlByReflection(xdoc);
		}

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TreeItem&lt;T&gt;.</returns>
        public TreeItem<T> Find(string id)
		{
			return _globalCollection[id];
		}
        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>LightCollection&lt;TreeItem&lt;T&gt;&gt;.</returns>
        public LightCollection<TreeItem<T>> Find(Predicate<TreeItem<T>> match)
		{
			LightCollection<TreeItem<T>> results = new LightCollection<TreeItem<T>>();
			for (int i = 0; i < _globalCollection.Count; i++)
			{
				if(match(_globalCollection[i]))
				{
					results.Add(_globalCollection[i]);
				}
			}
			return results;
		}

        /// <summary>
        /// To the XML.
        /// </summary>
        /// <param name="treeItemWriterDelegate">The tree item writer delegate.</param>
        /// <returns>System.String.</returns>
        public string ToXml(TreeItemXmlWriterDelegate treeItemWriterDelegate)
		{
			MemoryStream ms = new MemoryStream();
			XmlTextWriter xtw = new XmlTextWriter(ms,Encoding.UTF8);

			xtw.WriteStartDocument(true);
			xtw.WriteStartElement("TreeCollection");

			ToXml(treeItemWriterDelegate);

			xtw.WriteEndElement();
			xtw.WriteEndDocument();

			xtw.Flush();

			Stream stream = xtw.BaseStream;
			stream.Position = 0;

			StreamReader sr = new StreamReader(stream);
			string xml = sr.ReadToEnd();

			sr.Close();
			stream.Close();
			xtw.Close();

			return xml;
		}
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="treeItemWriterDelegate">The tree item writer delegate.</param>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public string ToString(TreeItemStringWriterDelegate treeItemWriterDelegate)
		{
			StringBuilder sb=new StringBuilder();
			ToString(null, sb, treeItemWriterDelegate);
			return sb.ToString();
		}
        /// <summary>
        /// To the index XML.
        /// </summary>
        /// <returns>System.String.</returns>
        public string ToIndexXml()
		{
			TreeItemXmlWriterDelegate writerDelegate = new TreeItemXmlWriterDelegate(IndexXmlWriterDelegate);
			return ToXml(writerDelegate);
		}
        /// <summary>
        /// To the index string.
        /// </summary>
        /// <returns>System.String.</returns>
        public string ToIndexString()
		{
			TreeItemStringWriterDelegate writerDelegate = new TreeItemStringWriterDelegate(IndexStringWriterDelegate);
			return ToString(writerDelegate);
		}
        /// <summary>
        /// To the XML by reflection.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string ToXmlByReflection()
		{
			throw new NotImplementedException();
		}

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
		{
			TreeItemStringWriterDelegate writerDelegate = new TreeItemStringWriterDelegate(StringWriterDelegate);
			StringBuilder sb = new StringBuilder();
			ToString(null,sb,writerDelegate);
			return sb.ToString();
		}

        /// <summary>
        /// Froms the XML node.
        /// </summary>
        /// <param name="treeCollection">The tree collection.</param>
        /// <param name="currentColl">The current coll.</param>
        /// <param name="xnode">The xnode.</param>
        /// <param name="readerDelegate">The reader delegate.</param>
        private static void FromXmlNode(TreeCollection<T> treeCollection,ref TreeItemCollection<T> currentColl, XmlNode xnode, TreeItemXmlReaderDelegate readerDelegate)
		{
			XmlNodeList xlist = xnode.SelectNodes("./TreeItem");

			for (int i = 0; i < xlist.Count; i++)
			{
				XmlNode currentNode = xlist[i];

				TreeItem<T> newItem = currentColl.Add(treeCollection.GlobalCollection.CreateFreeKey(), default(T));

				readerDelegate(ref newItem, currentNode);

				if (currentNode.ChildNodes.Count > 0)
				{
					TreeItemCollection<T> itemColl = newItem.Subitems;
					FromXmlNode(treeCollection,ref itemColl, xlist[i], readerDelegate);
				}
			}
		}
        /// <summary>
        /// Froms the XML by reflection.
        /// </summary>
        /// <param name="xdoc">The xdoc.</param>
        /// <returns>TreeCollection&lt;T&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        private static TreeCollection<T> FromXmlByReflection(XmlDocument xdoc)
		{
			throw new NotImplementedException();
		}

        /// <summary>
        /// Strings the writer delegate.
        /// </summary>
        /// <param name="current">The current.</param>
        /// <param name="sb">The sb.</param>
        private void StringWriterDelegate(TreeItem<T> current, StringBuilder sb)
		{
			object value = current.Value;
			sb.Append('\t', current.Level);
			if (value != null)
			{
				sb.AppendLine(current.Value.ToString());
			}
			else
			{
				sb.AppendLine("null");
			}
		}
        /// <summary>
        /// Indexes the XML writer delegate.
        /// </summary>
        /// <param name="current">The current.</param>
        /// <param name="xtw">The XTW.</param>
        private void IndexXmlWriterDelegate(TreeItem<T> current, XmlTextWriter xtw)
		{
			xtw.WriteStartElement("TreeItem");
			xtw.WriteAttributeString("Id", current.Id);
			xtw.WriteEndElement(); //TreeItem
		}
        /// <summary>
        /// Indexes the string writer delegate.
        /// </summary>
        /// <param name="current">The current.</param>
        /// <param name="sb">The sb.</param>
        private void IndexStringWriterDelegate(TreeItem<T> current, StringBuilder sb)
		{
			sb.Append('\t', current.Level);
			sb.AppendLine("[" + current.Id + "]");
		}

        /// <summary>
        /// To the index XML.
        /// </summary>
        /// <param name="currentId">The current identifier.</param>
        /// <param name="xtw">The XTW.</param>
        private void ToIndexXml(string currentId,XmlTextWriter xtw)
		{
			LightCollection<string> items;
			if (currentId == null)
			{
				items = _rootItems;
			}
			else
			{
				items = _globalCollection[currentId].Subitems.ItemsId;
			}
			for (int i = 0; i < items.Count; i++)
			{
				xtw.WriteStartElement("TreeItem");
				xtw.WriteAttributeString("Id", items[i]);
				ToIndexXml(items[i], xtw);
				xtw.WriteEndElement(); //TreeItem
			}
		}
        /// <summary>
        /// To the XML.
        /// </summary>
        /// <param name="currentId">The current identifier.</param>
        /// <param name="xtw">The XTW.</param>
        /// <param name="treeItemWriterDelegate">The tree item writer delegate.</param>
        private void ToXml(string currentId, XmlTextWriter xtw, TreeItemXmlWriterDelegate treeItemWriterDelegate)
		{
			LightCollection<string> items;
			if (currentId == null)
			{
				items = _rootItems;
			}
			else
			{
				items = _globalCollection[currentId].Subitems.ItemsId;
			}
			for (int i = 0; i < items.Count; i++)
			{
				treeItemWriterDelegate(_globalCollection[items[i]], xtw);
				ToXml(items[i], xtw, treeItemWriterDelegate);
			}
		}
        /// <summary>
        /// To the string.
        /// </summary>
        /// <param name="currentId">The current identifier.</param>
        /// <param name="sb">The sb.</param>
        /// <param name="treeItemWriterDelegate">The tree item writer delegate.</param>
        private void ToString(string currentId, StringBuilder sb, TreeItemStringWriterDelegate treeItemWriterDelegate)
		{
			LightCollection<string> items;
			if (currentId == null)
			{
				items = _rootItems;
			}
			else
			{
				items = _globalCollection[currentId].Subitems.ItemsId;
			}
			for (int i = 0; i < items.Count; i++)
			{
				treeItemWriterDelegate(_globalCollection[items[i]], sb);
				ToString(items[i], sb, treeItemWriterDelegate);
			}
		}

	}
}
