namespace SOLIDPrinciples
{
    // Single Responsibility P.
    //Dikdörtgenin alanı hesaplandı.
    public class SingleResponsibility
    {
        const string errorMessage = "Negatif değer girildi.";
        ValidationClass validation = new ValidationClass();
        public int Area(int longEdge, int shortEdge)
        {
            if (!validation.IsValid(shortEdge, longEdge))
            {
                throw new Exception(errorMessage);
            }
            return longEdge * shortEdge;
        }
    }
    public class ValidationClass
    {
        public bool IsValid(int x, int y)
        {
            return x < 0 || y < 0 ? false : true;
        }
    }


    // Open - Closed P.
    //Dikdörtgenin çevresi hesaplandı.
    public interface IOperation
    {
        int Operation(ValidationClass validation, int longEdge, int shortEdge);
    }
    public class Perimeter : IOperation
    {
        public int Operation(ValidationClass validation, int longEdge, int shortEdge)
        {
            const string errMessage = "Uygun bir değer girilmedi.";
            if (!validation.IsValid(longEdge, shortEdge))
            {
                throw new Exception(errMessage);
            }
            return 2 * longEdge + 2 * shortEdge;
        }
    }
    public class OpenClosed
    {
        private IOperation _operation;
        private ValidationClass validation = new ValidationClass();
        public OpenClosed(IOperation operation)
        {
            _operation = operation;
        }
        public int main(int longEdge, int shortEdge)
        {
            return _operation.Operation(validation, longEdge, shortEdge);
        }
    }



    //Liskov Substitution P.
    //Visitor: Ana sayfaya erişebilir.
    //Kullanıcı: Hem ana sayfaya hem de profiline erişebilir.
    public abstract class Person
    {
        public virtual string mainPage() { return "Main page is displaying."; }
    }
    public interface IsLogin
    {
        public string userPage();
    }
    public class Visitor : Person
    {
        public override string mainPage() { return "Main page is displaying."; }
    }
    public class User : Person, IsLogin
    {
        public override string mainPage()
        {
            return "Main page is displaying.";
        }
        public string userPage()
        {
            return "User page is displaying.";
        }
    }



    //Interface Segregation P.
    public interface ITheLiving
    {
        string Sleep();
        string Eat();
    }
    public interface IFly
    {
        string Fly();
    }
    public interface IMobilePhone
    {
        string Phone();
    }
    public class Human : ITheLiving, IMobilePhone
    {
        public string Eat()
        {
            return "I can eat.";
        }

        public string Phone()
        {
            return "I can use phone.";
        }

        public string Sleep()
        {
            return "I can sleep.";
        }
    }
    public class Cat : ITheLiving
    {
        public string Eat()
        {
            return "I can eat.";
        }

        public string Sleep()
        {
            return "I can sleep.";
        }
    }
    public class Bird : ITheLiving, IFly
    {
        public string Eat()
        {
            return "I can eat.";
        }

        public string Fly()
        {
            return "I can fly.";
        }

        public string Sleep()
        {
            return "I can sleep.";
        }
    }



    //Dependency Inversion P.
    //Toplama işlemi için : number 0 dan küçük mü ?
    //Bölme işlemi için : bölen 0 mı ?
    public interface IOperationValidation
    {
        bool IsValid(int a, int b);
    }
    public class SumValidation : IOperationValidation
    {
        public bool IsValid(int a, int b)
        {
            return a < 0 || b < 0
                   ? true
                   : false;
        }
    }
    public class DivideValidation : IOperationValidation
    {
        public bool IsValid(int a, int b)
        {
            return a == 0 || b == 0
                   ? true
                   : false;
        }
    }
    public class Validation
    {
        private IOperationValidation _operationValidation;
        public Validation(IOperationValidation operationValidation)
        {
            _operationValidation = operationValidation;
        }
        public bool IsValid(int a, int b)
        {
            return _operationValidation.IsValid(a, b);
        }
    }
}
