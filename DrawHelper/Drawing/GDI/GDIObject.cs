// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="GDIObject.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI
{
    /// <summary>
    /// Summary description for GDIObject.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public abstract class GDIObject : IDisposable
	{
        /// <summary>
        /// The is created
        /// </summary>
        protected bool IsCreated = false;

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        protected virtual void Destroy()
		{
			IsCreated = false;
			MemHandler.Remove(this);
		}

        /// <summary>
        /// Creates this instance.
        /// </summary>
        protected virtual void Create()
		{
			IsCreated = true;
			MemHandler.Add(this);
		}

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
		{
			this.Destroy();
		}

		#endregion
	}
}