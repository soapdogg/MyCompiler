﻿using System.Text;
using MyCompiler.Program.Interfaces;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryAssignOperatorNode : IBinaryAssignOperatorNode
    {
        private readonly Translatable translatable;
        private readonly Typable typable;
        private readonly string op;
        private readonly IExpressionNode leftExpression, rightExpression;
        private readonly bool isLeftArray;

        public string Type => typable.Type;
        public string Address => typable.Address;

        public BinaryAssignOperatorNode(IExpressionChild left, IExpressionChild right, string op)
        {
            translatable = new Translatable();
            typable = new Typable();
            leftExpression = new ExpressionNode(left);
            var value = leftExpression.Child as ILeftHandValue;
            value?.SetAsLValue();
            rightExpression = new ExpressionNode(right);
            this.op = op;
            typable.Type = leftExpression.Type.Equals("double") || rightExpression.Type.Equals("double")
                ? "double"
                : "int";
            isLeftArray = leftExpression.Child is BinaryArrayOperatorNode;
        }

        public void Translate()
        {
            leftExpression.Translate();
            rightExpression.Translate();
            translatable.Translate();
            typable.GenerateNewAddress();
        }

        public string PrettyPrint()
        {
            return translatable.IsTranslated
                ? PrettyPrintTranslated()
                : $"{leftExpression.PrettyPrint()} {op}={rightExpression.PrettyPrint()}";
        }

        private string PrettyPrintTranslated() => isLeftArray ? PrettyPrintLeftArray() : PrettyPrintLeftVariable();

        private string PrettyPrintLeftArray()
        {
            IBinaryArrayOperatorNode leftChild = (IBinaryArrayOperatorNode) leftExpression.Child;
            string leftChildLValue = leftChild.LValueString; 
            StringBuilder sb = new StringBuilder();
            sb.Append(leftChild.TranslatedInnerExpression);
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, leftChildLValue));
            sb.Append(rightExpression.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address,
                $"{Address} {op} {rightExpression.Address}"));
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(leftChildLValue, Address));
            return sb.ToString();
        }

        private string PrettyPrintLeftVariable()
        {
            IVariableExpressionNode leftChild = (IVariableExpressionNode) leftExpression.Child;
            string leftChildLValue = leftChild.LValueString;
            StringBuilder sb = new StringBuilder();
            sb.Append(rightExpression.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address,
                $"{leftChildLValue} {op} {rightExpression.Address}"));
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(leftChildLValue, Address));
            return sb.ToString();
        }
    }
}
