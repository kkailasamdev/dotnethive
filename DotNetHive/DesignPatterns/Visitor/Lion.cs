namespace DotNetHive.DesignPatterns.Visitor
{
    internal class Lion : Animal
    {
        public override void Accept(IAnimalVisitor animalVisitor)
        {
            animalVisitor.Visit(this);
        }
    }
}
