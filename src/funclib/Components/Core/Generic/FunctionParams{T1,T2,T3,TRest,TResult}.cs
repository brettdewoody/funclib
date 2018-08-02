﻿using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core.Generic
{
    /// <summary>
    /// Creates a <see cref="FunctionParams{T1, T2, T3, T4, TResult}"/> from a <see cref="Func{T1, T2, T3, T4[], TResult}"/>.
    /// </summary>
    /// <typeparam name="T1">First parameter of the function.</typeparam>
    /// <typeparam name="T2">Second parameter of the function.</typeparam>
    /// <typeparam name="T3">Third parameter of the function.</typeparam>
    /// <typeparam name="TRest">Generic type of the rest of the parameters.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class FunctionParams<T1, T2, T3, TRest, TResult> :
        IFunctionParams<T1, T2, T3, TRest, TResult>
    {
        readonly Func<T1, T2, T3, TRest[], TResult> _func;

        /// <summary>
        /// Creates a <see cref="FunctionParams{T1, T2, T3, T4, TResult}"/> from a <see cref="Func{T1, T2, T3, T4[], TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1, T2, T3, T4[], TResult}"/> to execute.</param>
        public FunctionParams(Func<T1, T2, T3, TRest[], TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1, T2, T3, T4[], TResult}"/>.
        /// </summary>
        /// <param name="x">First parameter of the function.</param>
        /// <param name="y">Second parameter of the function.</param>
        /// <param name="z">Third parameter of the function.</param>
        /// <param name="args">Array of parameters.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1, T2, T3, T4[], TResult}"/> function.
        /// </returns>
        public TResult Invoke(T1 x, T2 y, T3 z, params TRest[] args) => this._func(x, y, z, args);
    }
}
