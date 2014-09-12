// ***********************************************************************
// Assembly         : Tako.Component.Extension
// Author           : 余小章
// Created          : 08-14-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="StaticClassTransparentDynamicObject.cs" company="">
//     Copyright (c) . 余小章 . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Dynamic;

/// <summary>
/// The DynamicObjectExtension namespace.
/// </summary>
namespace Tako.Component.Extension
{
    /// <summary>
    /// Class StaticClassTransparentDynamicObject.
    /// </summary>
    public class StaticClassTransparentDynamicObject : DynamicObject
    {
        /// <summary>
        /// The _static class type
        /// </summary>
        private Type _staticClassType;

        /// <summary>
        /// The _transparent
        /// </summary>
        private Transparent _transparent = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticClassTransparentDynamicObject" /> class.
        /// </summary>
        /// <param name="staticClassType">Type of the static class.</param>
        /// <exception cref="System.NotSupportedException"></exception>
        public StaticClassTransparentDynamicObject(Type staticClassType)
        {
            if (!(staticClassType.IsAbstract && staticClassType.IsSealed))
            {
                throw new NotSupportedException(string.Format("The '{0}' not static object", staticClassType));
            }
            this._staticClassType = staticClassType;
            if (_transparent == null)
            {
                _transparent = new Transparent();
            }
        }

        /// <summary>
        /// Provides the implementation for operations that set member values. Classes derived from the <see cref="T:System.Dynamic.DynamicObject" /> class can override this method to specify dynamic behavior for operations such as setting a value for a property.
        /// </summary>
        /// <param name="binder">Provides information about the object that called the dynamic operation. The binder.Name property provides the name of the member to which the value is being assigned. For example, for the statement sampleObject.SampleProperty = "Test", where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, binder.Name returns "SampleProperty". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param>
        /// <param name="value">The value to set to the member. For example, for sampleObject.SampleProperty = "Test", where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, the <paramref name="value" /> is "Test".</param>
        /// <returns>true if the operation is successful; otherwise, false. If this method returns false, the run-time binder of the language determines the behavior. (In most cases, a language-specific run-time exception is thrown.)</returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            return _transparent.TrySetMember(null, this._staticClassType, binder, value);
        }

        /// <summary>
        /// Provides the implementation for operations that get member values. Classes derived from the <see cref="T:System.Dynamic.DynamicObject" /> class can override this method to specify dynamic behavior for operations such as getting a value for a property.
        /// </summary>
        /// <param name="binder">Provides information about the object that called the dynamic operation. The binder.Name property provides the name of the member on which the dynamic operation is performed. For example, for the Console.WriteLine(sampleObject.SampleProperty) statement, where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, binder.Name returns "SampleProperty". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param>
        /// <param name="result">The result of the get operation. For example, if the method is called for a property, you can assign the property value to <paramref name="result" />.</param>
        /// <returns>true if the operation is successful; otherwise, false. If this method returns false, the run-time binder of the language determines the behavior. (In most cases, a run-time exception is thrown.)</returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _transparent.TryGetMember(null, this._staticClassType, binder, out result);
        }

        /// <summary>
        /// Provides the implementation for operations that invoke a member. Classes derived from the <see cref="T:System.Dynamic.DynamicObject" /> class can override this method to specify dynamic behavior for operations such as calling a method.
        /// </summary>
        /// <param name="binder">Provides information about the dynamic operation. The binder.Name property provides the name of the member on which the dynamic operation is performed. For example, for the statement sampleObject.SampleMethod(100), where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, binder.Name returns "SampleMethod". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param>
        /// <param name="args">The arguments that are passed to the object member during the invoke operation. For example, for the statement sampleObject.SampleMethod(100), where sampleObject is derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, <paramref name="args[0]" /> is equal to 100.</param>
        /// <param name="result">The result of the member invocation.</param>
        /// <returns>true if the operation is successful; otherwise, false. If this method returns false, the run-time binder of the language determines the behavior. (In most cases, a language-specific run-time exception is thrown.)</returns>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            return _transparent.TryInvokeMember(null, this._staticClassType, binder, args, out result);
        }
    }
}