This is a proper code which is quite lisible and prevent from excepition which can occured.
is instrction will return true if message is of type tested in the if instruction.
as will try to parse the message object in the specified type. If it can't, it will assign null. But the ?. prevent any NullReferenceException that can occured.

But there is a major issue related to the if / else if statement which make a no scalable code.
First of all, if we need to add a new message type to manage, we must change this code to add an else if statement. This would make the class unreadable from top to bottom.
Then if a new method is added to an existing message, the corresponding if statment will have to be modified too in this piece of code.

An alternative is to crate an interface "IMessage" which will define a method "MessageTreatment"
This interface will have two purpose :
	_ All class "Message" will have the same interface implemented
	_ Each class "Message" can implement is own MessageTreatment. so if a new method is added, the call to that ethod can easily be added to method MessageTreatment whitout modifying any other class or project.

To be treated, All "Message" must now implement the "IMessage" interface.
Any custom class could be define as private and called in the "MessageTreatment". 

Now the code should be : 

if (message is IMessage)
{
	m.MessageTreatment();
}

interface IMessage
{
	void MessageTreatment();
}

class MessageA : IMessage
{
	private void MyCustomMethodOnA()
        {
        }

	public void MessageTreatment()
        {
                this.MyCustomMethodOnA();	
	}
}

class MessageB : IMessage
{
	private void MyCustomMethodOnB()
        {
        }

        private void SomeAdditionnalMethodOnB()
        {
	public void MessageTreatment()
        {
                this.MyCustomMethodOnB();
		this.SomeAdditionnalMethodOnB();
	}
}

In addition any private custom method can be mark as protected virtual instead of private.
This will permit to override them in a derived class if needed. The derived class will implement IMessage by inheritance.
the overritten code will be executed in place of the code in the super class.

The SmallDemo project show you an example of code and show the result in a console log.