namespace App01.Model.Application.Console
{
    public abstract class BaseFactory<T> : IFactory<T> where T:class
    {
        public abstract T Create(string pattern);
    }


    public class LayoutFactory : BaseFactory<ILayout<IFile>>
    {
        public override ILayout<IFile> Create(string pattern)
        {
            if(pattern.Equals("1")){
                return new Layout01();
            }else if(pattern.Equals("2"))
                return new Layout02();
            return null;
        }
    }
}
