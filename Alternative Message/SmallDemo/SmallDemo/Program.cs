using System;
using System.Collections.Generic;

namespace SmallDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IMessage> messages = new List<IMessage>();
            messages.Add(new MessageA());
            messages.Add(new MessageB());
            messages.Add(null);
            messages.Add(new MessageC());
            messages.Add(new MessageD());

            messages.ForEach((m) =>
                {
                    if (m is IMessage)
                    {
                        m.MessageTreatment();
                    }
                }
            );

            MessageC messageC = new MessageD();
            messageC.MessageTreatment();

            Console.ReadKey();
        }

        /// <summary>
        /// Define all message which must be implemented
        /// </summary>
        interface IMessage
        {
            void MessageTreatment();
        }

        /// <summary>
        /// Classe Message A
        /// </summary>
        class MessageA : IMessage
        {
            /// <summary>
            /// Custom Method writing in console which method is call
            /// </summary>
            private void MyCustomMethodOnA()
            {
                Console.WriteLine("MyCustomMethodOnA Called");
            }

            /// <summary>
            /// 
            /// </summary>
            public void MessageTreatment()
            {
                Console.WriteLine("Treatin Message A");
                this.MyCustomMethodOnA();
            }
        }

        class MessageB : IMessage
        {
            private void MyCustomMethodOnB()
            {
                Console.WriteLine("MyCustomMethodOnB Called");
            }
            private void SomeAdditionnalMethodOnB()
            {
                Console.WriteLine("SomeAdditionnalMethodOnB Called");
            }

            public void MessageTreatment()
            {
                Console.WriteLine("Treatin Message B");
                this.MyCustomMethodOnB();
                this.SomeAdditionnalMethodOnB();
            }
        }

        class MessageC : IMessage
        {
            protected virtual void MyCustomMethodOnC()
            {
                Console.WriteLine("MyCustomMethodOnC Called");
            }

            public void MessageTreatment()
            {
                Console.WriteLine("Treatin Message C");
                this.MyCustomMethodOnC();
            }
        }

        /// <summary>
        /// Show overriding method from MyCustomMethodOnC
        /// For message D there will be two message :
        /// Treatin Message C
        /// MyCustomMethodOnC Called on D!!
        /// </summary>
        class MessageD : MessageC
        {
            protected override void MyCustomMethodOnC()
            {
                Console.WriteLine("MyCustomMethodOnC Called on D!!");
            }
        }
    }
}
