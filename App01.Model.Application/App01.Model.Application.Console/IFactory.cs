namespace App01.Model.Application.Console
{
    public interface IFactory<T>
    {
        T Create(string pattern);
    }


    public interface ILayout<T>
    {
        T Convert(T file);
    }

    public abstract class BaseLayout<T> : ILayout<T>
    {
        public abstract T Convert(T file);
    }

    public class Layout01 : BaseLayout<IFile>
    {
        public override IFile Convert(IFile file)
        {
            file.Pattern="1";
            return file;
        }
    }

    public class Layout02 : BaseLayout<IFile>
    {
        public override IFile Convert(IFile file)
        {
            file.Pattern = "2";
            return file;
        }
    }

    public interface IFile
    {
        string Nome { get; set; }
        string Pattern{get;set;}
    }
    public class Arquivo : IFile {
        public string Nome { get; set; }
        public string Pattern { get;set; }
    }
}
