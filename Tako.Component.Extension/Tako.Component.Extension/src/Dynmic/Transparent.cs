// ***********************************************************************
// Assembly         : Tako.Component.Extension
// Author           : 余小章
// Created          : 08-14-2014
//
// Last Modified By : 余小章
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="Transparent.cs" company="余小章">
//     Copyright (c) . 余小章 . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

/// <summary>
/// The Core namespace.
/// </summary>
namespace Tako.Component.Extension
{
    /// <summary>
    /// Class Transparent.
    /// </summary>
    internal class Transparent
    {
        /// <summary>
        /// The s_ type arguments
        /// </summary>
        private static Func<InvokeMemberBinder, IList<Type>> s_TypeArguments = null;

        /// <summary>
        /// The clas s_ name
        /// </summary>
        private const string CLASS_NAME = "Microsoft.CSharp.RuntimeBinder.CSharpInvokeMemberBinder";

        /// <summary>
        /// Initializes a new instance of the <see cref="Transparent" /> class.
        /// </summary>
        public Transparent()
        {
            if (s_TypeArguments == null)
            {
                var type = typeof(RuntimeBinderException).Assembly.GetTypes().Single(
                    x => x.FullName == CLASS_NAME);

                var dynamicMethod = new DynamicMethod("@",
                    typeof(IList<Type>),
                    new[] { typeof(InvokeMemberBinder) },
                    true);
                //處理il
                var il = dynamicMethod.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Castclass, type);
                il.Emit(OpCodes.Call,
                    type.GetProperty("Microsoft.CSharp.RuntimeBinder.ICSharpInvokeOrInvokeMemberBinder.TypeArguments",
                        BindingFlags.Public
                        | BindingFlags.NonPublic
                        | BindingFlags.Instance
                        | BindingFlags.Static).GetGetMethod(true));
                il.Emit(OpCodes.Ret);

                //找出泛型參數
                s_TypeArguments =
                    (Func<InvokeMemberBinder, IList<Type>>)
                        dynamicMethod.CreateDelegate(typeof(Func<InvokeMemberBinder, IList<Type>>));
            }
        }

        /// <summary>
        /// Tries the set member.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="instanceType">Type of the instance.</param>
        /// <param name="binder">The binder.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.MissingMemberException"></exception>
        public bool TrySetMember(object instance, Type instanceType, SetMemberBinder binder, object value)
        {
            MemberInfo member = null;

            if (instance != null)
            {
                member = instance.GetType().GetMember(binder.Name,
                     BindingFlags.Static
                     | BindingFlags.Public
                     | BindingFlags.NonPublic
                     | BindingFlags.Instance).FirstOrDefault();
            }

            if (member == null)
            {
                member = instanceType.GetMember(binder.Name,
                 BindingFlags.Static
                 | BindingFlags.Public
                 | BindingFlags.NonPublic
                 | BindingFlags.Instance).FirstOrDefault();
            }
            if (member == null)
                throw new MissingMemberException(string.Format("Member '{0}' not found for type '{1}'", binder.Name, instanceType));

            if (member is PropertyInfo)
            {
                var propertyInfo = (member as PropertyInfo);
                if (instance == null)
                {
                    propertyInfo.SetValue(null, value, null);
                }
                else
                {
                    propertyInfo.SetValue(instance, value, null);
                }
                return true;
            }
            if (member is FieldInfo)
            {
                var fieldInfo = (member as FieldInfo);
                if (instance == null)
                {
                    fieldInfo.SetValue(null, value);
                }
                else
                {
                    fieldInfo.SetValue(instance, value);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Tries the get member.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="instanceType">Type of the instance.</param>
        /// <param name="binder">The binder.</param>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.MissingMemberException"></exception>
        public bool TryGetMember(object instance, Type instanceType, GetMemberBinder binder, out object result)
        {
            MemberInfo member = null;
            if (instance != null)
            {
                member = instance.GetType().GetMember(binder.Name,
                 BindingFlags.Static
                 | BindingFlags.Public
                 | BindingFlags.NonPublic
                 | BindingFlags.Instance).FirstOrDefault();
            }

            if (member == null)
            {
                member = instanceType.GetMember(binder.Name,
                 BindingFlags.Static
                 | BindingFlags.Public
                 | BindingFlags.NonPublic
                 | BindingFlags.Instance).FirstOrDefault();
            }

            if (member == null)
                throw new MissingMemberException(string.Format("Member '{0}' not found for type '{1}'", binder.Name, instanceType));

            if (member is PropertyInfo)
            {
                PropertyInfo propertyInfo = member as PropertyInfo;
                if (instance == null)
                {
                    result = propertyInfo.GetValue(null, null);
                }
                else
                {
                    result = propertyInfo.GetValue(instance, null);
                }
                return true;
            }
            if (member is FieldInfo)
            {
                FieldInfo fieldInfo = member as FieldInfo;
                if (instance == null)
                {
                    result = fieldInfo.GetValue(null);
                }
                else
                {
                    result = fieldInfo.GetValue(instance);
                }
                return true;
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Tries the invoke member.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="instanceType">Type of the instance.</param>
        /// <param name="binder">The binder.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.MissingMemberException"></exception>
        public bool TryInvokeMember(object instance, Type instanceType, InvokeMemberBinder binder, object[] args, out object result)
        {
            MethodInfo method = null;
            if (instance != null)
            {
                method = instance.GetType().GetMethod(binder.Name,
                   BindingFlags.Static
                   | BindingFlags.Public
                   | BindingFlags.NonPublic
                   | BindingFlags.Instance
                   );
            }

            if (method == null)
            {
                method = instanceType.GetMethod(binder.Name,
                  BindingFlags.Static
                  | BindingFlags.Public
                  | BindingFlags.NonPublic
                  | BindingFlags.Instance
                  );
            }
            if (method == null)
                throw new MissingMemberException(string.Format("Method '{0}' not found for type '{1}'", binder.Name, instanceType));
            if (method.IsGenericMethod)
            {
                var typeArguments = s_TypeArguments(binder);
                if (typeArguments.Count > 0)
                    method = method.MakeGenericMethod(typeArguments.ToArray());
            }

            if (instance == null)
            {
                result = method.Invoke(null, args);
            }
            else
            {
                result = method.Invoke(instance, args);
            }
            return true;
        }
    }
}