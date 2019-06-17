#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Global.Code.Attributes
* 项目描述 ：
* 类 名 称 ：CustomValidationAttributes
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Global.Code.Attributes
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-14 11:20:39
* 更新时间 ：2019-06-14 11:20:39
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BerryCore.Code.Attributes
{
    /// <summary>
    /// 功能描述    ：自定义数据验证特性  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-14 11:20:39 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-14 11:20:39 
    /// </summary>
    public class CustomValidationAttributes
    {
        #region DateTime验证，输入时间不能大于当前时间或者输入时间不能小于当前时间

        /// <summary>
        /// DateTime验证，输入时间不能大于当前时间或者输入时间不能小于当前时间
        /// <para>默认true，输入时间不能大于当前时间</para>
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class NotFutureTimeAttribute : ValidationAttribute
        {
            private readonly bool _flag;

            /// <summary>
            /// 默认true，输入时间不能大于当前时间
            /// </summary>
            /// <param name="flag"></param>
            public NotFutureTimeAttribute(bool flag = true)
            {
                this._flag = flag;
            }

            /// <summary>确定指定的值的对象是否有效。</summary>
            /// <param name="value">要验证的对象的值。</param>
            /// <returns>
            ///   <see langword="true" /> 如果指定的值是否有效，则为否则为 <see langword="false" />。
            /// </returns>
            public override bool IsValid(object value)
            {
                DateTime dt = (DateTime)value;
                if (_flag)
                {
                    //输入时间不能大于当前时间
                    if (dt < DateTime.Now)
                    {
                        return true;
                    }
                }
                else
                {
                    //输入时间不能小于当前时间
                    if (dt > DateTime.Now)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        #endregion DateTime验证，输入时间不能大于当前时间或者输入时间不能小于当前时间

        #region 验证字符串长度在[n,m]之间，n < m

        /// <summary>
        /// 验证字符串长度在[n,m]之间，n < m
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class StringBetweenLengthAttribute : ValidationAttribute
        {
            private readonly int _min;
            private readonly int _max;

            public StringBetweenLengthAttribute(int min, int max)
            {
                this._min = min;
                this._max = max;
            }

            /// <summary>确定指定的值的对象是否有效。</summary>
            /// <param name="value">要验证的对象的值。</param>
            /// <returns>
            ///   <see langword="true" /> 如果指定的值是否有效，则为否则为 <see langword="false" />。
            /// </returns>
            public override bool IsValid(object value)
            {
                if (value == null)
                {
                    return false;
                }

                string source = value.ToString();

                return source.Length >= _min && source.Length <= _max;
            }
        }

        #endregion 验证字符串长度在[n,m]之间，n < m

        #region 验证字符串只能是指定固定长度

        /// <summary>
        /// 验证字符串只能是指定固定长度
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class StringFixedLengthAttribute : ValidationAttribute
        {
            private readonly int[] _fixedLength;

            public StringFixedLengthAttribute(int[] fixedLength)
            {
                this._fixedLength = fixedLength;
            }

            /// <summary>确定指定的值的对象是否有效。</summary>
            /// <param name="value">要验证的对象的值。</param>
            /// <returns>
            ///   <see langword="true" /> 如果指定的值是否有效，则为否则为 <see langword="false" />。
            /// </returns>
            public override bool IsValid(object value)
            {
                if (value == null)
                {
                    return false;
                }

                string source = value.ToString();
                int thisStrLen = source.Length;

                return _fixedLength.Contains(thisStrLen);
            }
        }

        #endregion 验证字符串只能是指定固定长度

        #region 验证数字只能是指定的某些值

        /// <summary>
        /// 验证数字只能是指定的某些值
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class NumericalFixedValueAttribute : ValidationAttribute
        {
            private readonly long[] _fixedValue;

            public NumericalFixedValueAttribute(long[] fixedValue)
            {
                this._fixedValue = fixedValue;
            }

            /// <summary>确定指定的值的对象是否有效。</summary>
            /// <param name="value">要验证的对象的值。</param>
            /// <returns>
            ///   <see langword="true" /> 如果指定的值是否有效，则为否则为 <see langword="false" />。
            /// </returns>
            public override bool IsValid(object value)
            {
                if (value == null)
                {
                    return false;
                }

                long source = Convert.ToInt64(value);

                return _fixedValue.Contains(source);
            }
        }

        #endregion

        #region 验证数字取值范围

        /// <summary>
        /// 验证数字取值范围
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class NumberCheckAttribute : ValidationAttribute
        {
            /// <summary>
            /// 比较类型
            /// </summary>
            private readonly NumberRangeOfValueType _type;

            /// <summary>
            /// 阈值
            /// </summary>
            private readonly long _threshold;

            public NumberCheckAttribute(NumberRangeOfValueType type, int threshold)
            {
                this._type = type;
                this._threshold = threshold;
            }

            /// <summary>确定对象的指定值是否有效。</summary>
            /// <returns>如果指定的值有效，则为 true；否则，为 false。</returns>
            /// <param name="value">要验证的对象的值。</param>
            public override bool IsValid(object value)
            {
                if (value == null)
                {
                    return false;
                }

                long source = Convert.ToInt64(value);
                if (_type == NumberRangeOfValueType.GreaterThan)
                {
                    //大于
                    return source > _threshold;
                }
                else if ((_type & NumberRangeOfValueType.GreaterThan) == NumberRangeOfValueType.GreaterThan && (_type & NumberRangeOfValueType.Equal) == NumberRangeOfValueType.Equal)
                {
                    //大于等于
                    return source >= _threshold;
                }
                else if (_type == NumberRangeOfValueType.LessThan)
                {
                    //小于
                    return source < _threshold;
                }
                else if ((_type & NumberRangeOfValueType.LessThan) == NumberRangeOfValueType.LessThan && (_type & NumberRangeOfValueType.Equal) == NumberRangeOfValueType.Equal)
                {
                    //小于等于
                    return source <= _threshold;
                }
                else if (_type == NumberRangeOfValueType.Equal)
                {
                    //等于
                    return source == _threshold;
                }
                else if (_type == NumberRangeOfValueType.NotEqual)
                {
                    //不等于
                    return source != _threshold;
                }

                return false;
            }
        }

        #endregion 验证数字取值范围

        #region 校验金额，必须大于或者等于0

        /// <summary>
        /// 校验金额，必须大于或者等于0
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class CheckMoneyAttribute : ValidationAttribute
        {
            /// <summary>确定对象的指定值是否有效。</summary>
            /// <returns>如果指定的值有效，则为 true；否则，为 false。</returns>
            /// <param name="value">要验证的对象的值。</param>
            public override bool IsValid(object value)
            {
                if (value == null)
                {
                    return false;
                }

                decimal source = Convert.ToDecimal(value);

                return source >= 0;
            }
        }

        #endregion 校验金额，必须大于或者等于0
    }
}
