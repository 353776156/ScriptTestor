﻿using System;
using System.Collections.Generic;
using System.Text;
using Scorpio;
using Scorpio.CodeDom;
using Scorpio.Compiler;
using Scorpio.Exception;
namespace Scorpio.Variable
{
    public class ScriptNumberLong : ScriptNumber
    {
        public override ObjectType Type { get { return ObjectType.Number; } }
        public override int BranchType { get { return 1; } }
        public override object ObjectValue { get { return m_Value; } }
        public long Value { get { return m_Value; } }
        public long m_Value;
        public ScriptNumberLong(Script script, long value) : base(script)
        {
            m_Value = value;
        }
        public override ScriptNumber Calc(CALC c)
        {
            switch (c)
            {
                case CALC.PRE_INCREMENT:
                    ++m_Value;
                    break;
                case CALC.PRE_DECREMENT:
                    --m_Value;
                    break;
                case CALC.POST_INCREMENT:
                    return Script.CreateLong(m_Value++);
                case CALC.POST_DECREMENT:
                    return Script.CreateLong(m_Value--);
            }
            return this;
        }
        public override ScriptNumber Negative()
        {
            m_Value = -m_Value;
            return this;
        }
        public override ScriptObject Assign()
        {
            return Script.CreateLong(m_Value);
        }
        public override long ToLong()
        {
            return m_Value;
        }
        public override ScriptObject ComputePlus(ScriptNumber obj)
        {
            return Script.CreateLong(m_Value + obj.ToLong());
        }
        public override ScriptObject ComputeMinus(ScriptNumber obj)
        {
            return Script.CreateLong(m_Value - obj.ToLong());
        }
        public override ScriptObject ComputeMultiply(ScriptNumber obj)
        {
            return Script.CreateLong(m_Value * obj.ToLong());
        }
        public override ScriptObject ComputeDivide(ScriptNumber obj)
        {
            return Script.CreateLong(m_Value / obj.ToLong());
        }
        public override ScriptObject ComputeModulo(ScriptNumber obj)
        {
            return Script.CreateLong(m_Value % obj.ToLong());
        }
        public override ScriptObject AssignPlus(ScriptNumber obj)
        {
            m_Value += obj.ToLong();
            return this;
        }
        public override ScriptObject AssignMinus(ScriptNumber obj)
        {
            m_Value -= obj.ToLong();
            return this;
        }
        public override ScriptObject AssignMultiply(ScriptNumber obj)
        {
            m_Value *= obj.ToLong();
            return this;
        }
        public override ScriptObject AssignDivide(ScriptNumber obj)
        {
            m_Value /= obj.ToLong();
            return this;
        }
        public override ScriptObject AssignModulo(ScriptNumber obj)
        {
            m_Value %= obj.ToLong();
            return this;
        }
        public override bool Compare(TokenType type, CodeOperator oper, ScriptNumber num)
        {
            ScriptNumberLong val = num as ScriptNumberLong;
            if (val == null) throw new ExecutionException("数字比较 两边的数字类型不一致 请先转换再比较 ");
            switch (type)
            {
                case TokenType.Greater:
                    return m_Value > val.m_Value;
                case TokenType.GreaterOrEqual:
                    return m_Value >= val.m_Value;
                case TokenType.Less:
                    return m_Value < val.m_Value;
                case TokenType.LessOrEqual:
                    return m_Value <= val.m_Value;
            }
            return false;
        }
        public override ScriptObject Clone()
        {
            return Script.CreateLong(m_Value);
        }
    }
}
