// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ComInterfaces.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.Win32
{
    #region Interfaces

    /// <summary>
    /// Interface IShellFolder
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214E6-0000-0000-C000-000000000046")]
    public interface IShellFolder
    {
        // Translates a file object's or folder's display name into an item identifier list.
        // Return value: error code, if any
        /// <summary>
        /// Parses the display name.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="pbc">The PBC.</param>
        /// <param name="pszDisplayName">Display name of the PSZ.</param>
        /// <param name="pchEaten">The PCH eaten.</param>
        /// <param name="ppidl">The ppidl.</param>
        /// <param name="pdwAttributes">The PDW attributes.</param>
        /// <returns>System.UInt32.</returns>
        [PreserveSig()]
        uint ParseDisplayName(
            IntPtr hwnd,             // Optional window handle
            IntPtr pbc,              // Optional bind context that controls the parsing operation. This parameter is normally set to NULL. 
            [In(), MarshalAs(UnmanagedType.LPWStr)] 
                string pszDisplayName,   // Null-terminated UNICODE string with the display name.
            out uint pchEaten,       // Pointer to a ULONG value that receives the number of characters of the display name that was parsed.
            out IntPtr ppidl,        // Pointer to an ITEMIDLIST pointer that receives the item identifier list for the object.
            ref uint pdwAttributes); // Optional parameter that can be used to query for file attributes. This can be values from the SFGAO enum

        // Allows a client to determine the contents of a folder by creating an item identifier enumeration object and returning its IEnumIDList interface.
        // Return value: error code, if any
        /// <summary>
        /// Enums the objects.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="grfFlags">The GRF flags.</param>
        /// <param name="ppenumIDList">The ppenum identifier list.</param>
        /// <returns>System.UInt32.</returns>
        [PreserveSig()]
        uint EnumObjects(
            IntPtr hwnd,                    // If user input is required to perform the enumeration, this window handle should be used by the enumeration object as the parent window to take user input.
            SHCONTF grfFlags,               // Flags indicating which items to include in the enumeration. For a list of possible values, see the SHCONTF enum. 
            out IEnumIDList ppenumIDList);  // Address that receives a pointer to the IEnumIDList interface of the enumeration object created by this method. 

        // Retrieves an IShellFolder object for a subfolder.
        // Return value: error code, if any
        /// <summary>
        /// Binds to object.
        /// </summary>
        /// <param name="pidl">The pidl.</param>
        /// <param name="pbc">The PBC.</param>
        /// <param name="riid">The riid.</param>
        /// <param name="ppv">The PPV.</param>
        /// <returns>System.UInt32.</returns>
        [PreserveSig()]
        uint BindToObject(
            IntPtr pidl,            // Address of an ITEMIDLIST structure (PIDL) that identifies the subfolder.
            IntPtr pbc,             // Optional address of an IBindCtx interface on a bind context object to be used during this operation.
            [In()]
                ref Guid riid,          // Identifier of the interface to return. 
            out IShellFolder ppv);        // Address that receives the interface pointer.

        // Requests a pointer to an object's storage interface. 
        // Return value: error code, if any
        /// <summary>
        /// Binds to storage.
        /// </summary>
        /// <param name="pidl">The pidl.</param>
        /// <param name="pbc">The PBC.</param>
        /// <param name="riid">The riid.</param>
        /// <param name="ppv">The PPV.</param>
        /// <returns>System.UInt32.</returns>
        [PreserveSig()]
        uint BindToStorage(
            IntPtr pidl,            // Address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. 
            IntPtr pbc,             // Optional address of an IBindCtx interface on a bind context object to be used during this operation.
            [In()]
                ref Guid riid,          // Interface identifier (IID) of the requested storage interface.
            [MarshalAs(UnmanagedType.Interface)]
                out object ppv);        // Address that receives the interface pointer specified by riid.

        // Determines the relative order of two file objects or folders, given their item identifier lists. 
        // Return value: If this method is successful, the CODE field of the HRESULT contains one of the following values (the code can be retrived using the helper function GetHResultCode)...
        // A negative return value indicates that the first item should precede the second (pidl1 < pidl2). 
        // A positive return value indicates that the first item should follow the second (pidl1 > pidl2).  Zero A return value of zero indicates that the two items are the same (pidl1 = pidl2). 
        /// <summary>
        /// Compares the i ds.
        /// </summary>
        /// <param name="lParam">The l parameter.</param>
        /// <param name="pidl1">The pidl1.</param>
        /// <param name="pidl2">The pidl2.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig()]
        int CompareIDs(
            int lParam,             // Value that specifies how the comparison should be performed. The lower sixteen bits of lParam define the sorting rule.
            // The upper sixteen bits of lParam are used for flags that modify the sorting rule. values can be from the SHCIDS enum
            IntPtr pidl1,           // Pointer to the first item's ITEMIDLIST structure.
            IntPtr pidl2);          // Pointer to the second item's ITEMIDLIST structure.

        // Requests an object that can be used to obtain information from or interact with a folder object.
        // Return value: error code, if any
        /// <summary>
        /// Creates the view object.
        /// </summary>
        /// <param name="hwndOwner">The HWND owner.</param>
        /// <param name="riid">The riid.</param>
        /// <param name="ppv">The PPV.</param>
        /// <returns>System.UInt32.</returns>
        [PreserveSig()]
        uint CreateViewObject(
            IntPtr hwndOwner,       // Handle to the owner window.
            [In()]
                ref Guid riid,          // Identifier of the requested interface.
            [MarshalAs(UnmanagedType.Interface)]
                out object ppv);        // Address of a pointer to the requested interface. 

        // Retrieves the attributes of one or more file objects or subfolders. 
        // Return value: error code, if any
        /// <summary>
        /// Gets the attributes of.
        /// </summary>
        /// <param name="cidl">The cidl.</param>
        /// <param name="apidl">The apidl.</param>
        /// <param name="rgfInOut">The RGF in out.</param>
        /// <returns>System.UInt32.</returns>
        [PreserveSig()]
        uint GetAttributesOf(
            int cidl,               // Number of file objects from which to retrieve attributes. 
            out IntPtr apidl,           // Address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object relative to the parent folder.
            out SFGAOF rgfInOut);       // Address of a single ULONG value that, on entry, contains the attributes that the caller is requesting. On exit, this value contains the requested attributes that are common to all of the specified objects. this value can be from the SFGAO enum

        // Retrieves an OLE interface that can be used to carry out actions on the specified file objects or folders. 
        // Return value: error code, if any
        /// <summary>
        /// Gets the UI object of.
        /// </summary>
        /// <param name="hwndOwner">The HWND owner.</param>
        /// <param name="cidl">The cidl.</param>
        /// <param name="apidl">The apidl.</param>
        /// <param name="riid">The riid.</param>
        /// <param name="rgfReserved">The RGF reserved.</param>
        /// <param name="ppv">The PPV.</param>
        /// <returns>System.UInt32.</returns>
        [PreserveSig()]
        uint GetUIObjectOf(
            IntPtr hwndOwner,       // Handle to the owner window that the client should specify if it displays a dialog box or message box.
            int cidl,               // Number of file objects or subfolders specified in the apidl parameter. 
            [In(), MarshalAs(UnmanagedType.LPArray)] IntPtr[]
            apidl,                  // Address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object or subfolder relative to the parent folder.
            [In()]
                ref Guid riid,          // Identifier of the COM interface object to return.
            IntPtr rgfReserved,     // Reserved. 
            [MarshalAs(UnmanagedType.Interface)]
                out object ppv);        // Pointer to the requested interface.

        // Retrieves the display name for the specified file object or subfolder. 
        // Return value: error code, if any
        /// <summary>
        /// Gets the display name of.
        /// </summary>
        /// <param name="pidl">The pidl.</param>
        /// <param name="uFlags">The u flags.</param>
        /// <param name="pName">Name of the p.</param>
        /// <returns>System.UInt32.</returns>
        [PreserveSig()]
        uint GetDisplayNameOf(
            IntPtr pidl,            // Address of an ITEMIDLIST structure (PIDL) that uniquely identifies the file object or subfolder relative to the parent folder. 
            SHGNO uFlags,           // Flags used to request the type of display name to return. For a list of possible values. 
            out STRRET pName);      // Address of a STRRET structure in which to return the display name.

        // Sets the display name of a file object or subfolder, changing the item identifier in the process.
        // Return value: error code, if any
        /// <summary>
        /// Sets the name of.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="pidl">The pidl.</param>
        /// <param name="pszName">Name of the PSZ.</param>
        /// <param name="uFlags">The u flags.</param>
        /// <param name="ppidlOut">The ppidl out.</param>
        /// <returns>System.UInt32.</returns>
        [PreserveSig()]
        uint SetNameOf(
            IntPtr hwnd,            // Handle to the owner window of any dialog or message boxes that the client displays.
            IntPtr pidl,            // Pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative to the parent folder. 
            [In(), MarshalAs(UnmanagedType.LPWStr)] 
                string pszName,         // Pointer to a null-terminated string that specifies the new display name. 
            SHGNO uFlags,           // Flags indicating the type of name specified by the lpszName parameter. For a list of possible values, see the description of the SHGNO enum. 
            out IntPtr ppidlOut);   // Address of a pointer to an ITEMIDLIST structure which receives the new ITEMIDLIST. 
    }

    /// <summary>
    /// Interface IEnumIDList
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F2-0000-0000-C000-000000000046")]
    public interface IEnumIDList
    {

        // Retrieves the specified number of item identifiers in the enumeration sequence and advances the current position by the number of items retrieved. 
        /// <summary>
        /// Nexts the specified celt.
        /// </summary>
        /// <param name="celt">The celt.</param>
        /// <param name="rgelt">The rgelt.</param>
        /// <param name="pceltFetched">The pcelt fetched.</param>
        /// <returns>System.UInt32.</returns>
        [PreserveSig()]
        uint Next(
            uint celt,                // Number of elements in the array pointed to by the rgelt parameter.
            out IntPtr rgelt,         // Address of an array of ITEMIDLIST pointers that receives the item identifiers. The implementation must allocate these item identifiers using the Shell's allocator (retrieved by the SHGetMalloc function). 
            // The calling application is responsible for freeing the item identifiers using the Shell's allocator.
            out Int32 pceltFetched    // Address of a value that receives a count of the item identifiers actually returned in rgelt. The count can be smaller than the value specified in the celt parameter. This parameter can be NULL only if celt is one. 
            );

        // Skips over the specified number of elements in the enumeration sequence. 
        /// <summary>
        /// Skips the specified celt.
        /// </summary>
        /// <param name="celt">The celt.</param>
        /// <returns>System.UInt32.</returns>
        [PreserveSig()]
        uint Skip(
            uint celt                 // Number of item identifiers to skip.
            );

        // Returns to the beginning of the enumeration sequence. 
        /// <summary>
        /// Resets this instance.
        /// </summary>
        /// <returns>System.UInt32.</returns>
        [PreserveSig()]
        uint Reset();

        // Creates a new item enumeration object with the same contents and state as the current one. 
        /// <summary>
        /// Clones the specified ppenum.
        /// </summary>
        /// <param name="ppenum">The ppenum.</param>
        /// <returns>System.UInt32.</returns>
        [PreserveSig()]
        uint Clone(
            out IEnumIDList ppenum    // Address of a pointer to the new enumeration object. The calling application must eventually free the new object by calling its Release member function. 
            );
    }

    #endregion
}
