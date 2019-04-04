// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="KnownAnimationFunctions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.Animation
{
    /// <summary>
    ///     Contains a list of all known animation functions
    /// </summary>
    public enum KnownAnimationFunctions
    {
        /// <summary>
        ///     No known animation function
        /// </summary>
        None,

        /// <summary>
        ///     The bounce ease-out animation function.
        /// </summary>
        /// 
        BounceEaseOut,

        /// <summary>
        ///     The bounce ease-in animation function.
        /// </summary>
        /// 
        BounceEaseIn,

        /// <summary>
        ///     The bounce ease-in-out animation function.
        /// </summary>
        /// 
        BounceEaseInOut,

        /// <summary>
        ///     The bounce ease-out-in animation function.
        /// </summary>
        /// 
        BounceEaseOutIn,

        /// <summary>
        ///     The cubic ease-in animation function.
        /// </summary>
        /// 
        CubicEaseIn,

        /// <summary>
        ///     The cubic ease-in and ease-out animation function.
        /// </summary>
        CubicEaseInOut,

        /// <summary>
        ///     The cubic ease-out animation function.
        /// </summary>
        CubicEaseOut,

        /// <summary>
        ///     The liner animation function.
        /// </summary>
        Liner,

        /// <summary>
        ///     The circular ease-in and ease-out animation function.
        /// </summary>
        CircularEaseInOut,

        /// <summary>
        ///     The circular ease-in animation function.
        /// </summary>
        CircularEaseIn,

        /// <summary>
        ///     The circular ease-out animation function.
        /// </summary>
        CircularEaseOut,

        /// <summary>
        ///     The quadratic ease-in animation function.
        /// </summary>
        QuadraticEaseIn,

        /// <summary>
        ///     The quadratic ease-out animation function.
        /// </summary>
        QuadraticEaseOut,

        /// <summary>
        ///     The quadratic ease-in and ease-out animation function.
        /// </summary>
        QuadraticEaseInOut,

        /// <summary>
        ///     The quartic ease-in animation function.
        /// </summary>
        QuarticEaseIn,

        /// <summary>
        ///     The quartic ease-out animation function.
        /// </summary>
        QuarticEaseOut,

        /// <summary>
        ///     The quartic ease-in and ease-out animation function.
        /// </summary>
        QuarticEaseInOut,

        /// <summary>
        ///     The quintic ease-in and ease-out animation function.
        /// </summary>
        QuinticEaseInOut,

        /// <summary>
        ///     The quintic ease-in animation function.
        /// </summary>
        QuinticEaseIn,

        /// <summary>
        ///     The quintic ease-out animation function.
        /// </summary>
        QuinticEaseOut,

        /// <summary>
        ///     The sinusoidal ease-in animation function.
        /// </summary>
        SinusoidalEaseIn,

        /// <summary>
        ///     The sinusoidal ease-out animation function.
        /// </summary>
        SinusoidalEaseOut,

        /// <summary>
        ///     The sinusoidal ease-in and ease-out animation function.
        /// </summary>
        SinusoidalEaseInOut,

        /// <summary>
        ///     The exponential ease-in animation function.
        /// </summary>
        ExponentialEaseIn,

        /// <summary>
        ///     The exponential ease-out animation function.
        /// </summary>
        ExponentialEaseOut,

        /// <summary>
        ///     The exponential ease-in and ease-out animation function.
        /// </summary>
        ExponentialEaseInOut,

        //-----------------------------------Zeroit Additions------------------------//
        //Linear,
        //EaseIn,
        //EaseOut,
        //EaseInAndOut,

        /// <summary>
        ///     The Linear animation function.
        /// </summary>
        LinearTween,

        /// <summary>
        ///     The ease-in quad animation function.
        /// </summary>
        EaseInQuad,

        /// <summary>
        ///     The ease-out quad animation function.
        /// </summary>
        EaseOutQuad,

        /// <summary>
        ///     The ease-in-out quad animation function.
        /// </summary>
        EaseInOutQuad,

        /// <summary>
        ///     The ease-in cubic animation function.
        /// </summary>
        EaseInCubic,

        /// <summary>
        ///     The ease-out cubic animation function.
        /// </summary>
        EaseOutCubic,

        /// <summary>
        ///     The ease-in-out cubic animation function.
        /// </summary>
        EaseInOutCubic,

        /// <summary>
        ///     The ease-in quart animation function.
        /// </summary>
        EaseInQuart,

        /// <summary>
        ///     The ease-out quart animation function.
        /// </summary>
        EaseOutQuart,

        /// <summary>
        ///     The ease-in-out quart animation function.
        /// </summary>
        EaseInOutQuart,

        /// <summary>
        ///     The ease-in quint animation function.
        /// </summary>
        EaseInQuint,

        /// <summary>
        ///     The ease-out quint animation function.
        /// </summary>
        EaseOutQuint,

        /// <summary>
        ///     The ease-in-out quint animation function.
        /// </summary>
        EaseInOutQuint,

        /// <summary>
        ///     The ease-in sine animation function.
        /// </summary>
        EaseInSine,

        /// <summary>
        ///     The ease-out sine animation function.
        /// </summary>
        EaseOutSine,

        /// <summary>
        ///     The ease-in-out sine animation function.
        /// </summary>
        EaseInOutSine,

        /// <summary>
        ///     The ease-in expo animation function.
        /// </summary>
        EaseInExpo,

        /// <summary>
        ///     The ease-out expo animation function.
        /// </summary>
        EaseOutExpo,

        /// <summary>
        ///     The ease-in-out expo animation function.
        /// </summary>
        EaseInOutExpo,

        /// <summary>
        ///     The ease-in circ animation function.
        /// </summary>
        EaseInCirc,

        /// <summary>
        ///     The ease-out circ animation function.
        /// </summary>
        EaseOutCirc,

        /// <summary>
        ///     The ease-in-out circ animation function.
        /// </summary>
        EaseInOutCirc,

        /// <summary>
        ///     The elastic-ease-out quad animation function.
        /// </summary>
        ElasticEaseOut,

        /// <summary>
        ///     The elastic-ease-in quad animation function.
        /// </summary>
        ElasticEaseIn,

        /// <summary>
        ///     The elastic-ease-in-out quad animation function.
        /// </summary>
        ElasticEaseInOut,

        /// <summary>
        ///     The elastic-ease-out-in quad animation function.
        /// </summary>
        ElasticEaseOutIn,

        /// <summary>
        ///     The bounce-ease-out-v2 quad animation function.
        /// </summary>
        BounceEaseOutV2,

        /// <summary>
        ///     The bounce-ease-in-v2 quad animation function.
        /// </summary>
        BounceEaseInV2,

        /// <summary>
        ///     The bounce-ease-in-out-v2 quad animation function.
        /// </summary>
        BounceEaseInOutV2,

        /// <summary>
        ///     The bounce-ease-out-in-v2 quad animation function.
        /// </summary>
        BounceEaseOutInV2,

        /// <summary>
        ///     The back-ease-out quad animation function.
        /// </summary>
        BackEaseOut,

        /// <summary>
        ///     The back-ease-in quad animation function.
        /// </summary>
        BackEaseIn,

        /// <summary>
        ///     The back-ease-in-out quad animation function.
        /// </summary>
        BackEaseInOut,

        /// <summary>
        ///     The back-ease-out-in quad animation function.
        /// </summary>
        BackEaseOutIn
        //-----------------------------------Zeroit Additions------------------------//


    }
}