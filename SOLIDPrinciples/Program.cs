namespace SOLIDPrinciples
{
    // Single Responsibility P.
    // Dikdörtgenin alanı hesaplandı.
    // Girilen sayının pozitif değer kontrolünün ayrı bir doğrulama sınıfı tarafından
    // yapılması ile bu prensip gerçekleştirilmiştir.
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
    // Dikdörtgenin alanının ardından çevre hesabı da yapıldı.
    // Eklenen her bir yeni metod için doğrulama işleminin de yapılması gerektiğinden 
    // interface aracılığı ile bu işlem merkezi bir yere alındı.
    // interface operasyonlarına constructor içerisinde interface'den üretilen instance ile ulaşıldı. 
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


    // Liskov Substitution P.
    // Alt sınıflar türetildikleri üst sınıfların yerine kullanıldıklarında uygulama akışını bozmamalıdır.
    // Her metod için ortak olan operasyonlar base sınıfta tutulmalıdır.
    // Visitor: Ana sayfaya erişebilir.
    // Kullanıcı: Hem ana sayfaya hem de profiline erişebilir.
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



    // Interface Segregation P.
    // Her class kendi kullanabileceği metodları içermeli, gereksiz metod içermemelidir.
    // Gerekli durumlarda interface'ler ayrıştırılmalıdır.
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


    // Dependency Inversion P.
    // Aralarında bağımlılık bulunan sınıflar doğrudan değil bir interface aracılığı ile
    // birbirleriyle haberleşmelilerdir. 
    // Toplama işlemi için : number 0 dan küçük mü ?
    // Bölme işlemi için : bölen 0 mı ?
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

        //dependency injection
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