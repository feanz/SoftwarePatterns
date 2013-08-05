The enumeration class pattern helps us deal with the issue of enum code pollution.  We often end up with code like this -

public void ProcessBonus(Employee employee)
{
    switch(employee.Type)
    {
        case EmployeeType.Manager:
            employee.Bonus = 1000m;
            break;
        case EmployeeType.Servant:
            employee.Bonus = 0.01m;
            break;
        case EmployeeType.AssistantToTheRegionalManager:
            employee.Bonus = 1.0m;
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
}

This code has lots of issues for a start it does not obey the open closed principle, behaviour related to the enum will be scattered around the application and any new enumeration requires code updates probably in a lot of code areas;

We can replace this with an enumeration class that allows us to move type logic into one location. 