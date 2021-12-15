namespace DotNetHive.DesignPatterns.Visitor
{
    internal class Bear : Animal
    {
        public override void Accept(IAnimalVisitor animalVisitor)
        {
            animalVisitor.Visit(this);
        }
    }
}
