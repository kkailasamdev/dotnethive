using System;

namespace DotNetHive.DesignPatterns.Visitor
{
    internal class Animal
    {
        public virtual void Accept(IAnimalVisitor animalVisitor) => throw new NotImplementedException();
    }
}
