using System;

namespace SoftwarePatterns.Core.Interpreter
{
	// BNF:
	// <patient> ::= <personaldetails> <patienttype> <medicalhistory> <diagnosis> <medication>
	// <patienttype> ::= <outpatient> | <intensivecare>
	// <personaldetails> :: = <name> <dateofbirth> <postcode>
	// <medicalhistory> ::= { <medicalevents> }
	// <diagnosis> :: = <description>
	// <medication> ::= { <medicine> }
	public class Patient : Expression
	{
		private readonly PersonalDetial personalDetails;
		private readonly IPatientType patientType;
		private readonly MedicalHistory medicalHistory;
		private readonly Diagnosis diagnosis;
		private readonly Medication medication;

		public Patient(PersonalDetial personalDetails, IPatientType patientType, MedicalHistory medicalHistory, Diagnosis diagnosis, Medication medication)
		{
			this.personalDetails = personalDetails;
			this.patientType = patientType;
			this.medicalHistory = medicalHistory;
			this.diagnosis = diagnosis;
			this.medication = medication;
		}

		public void Interpret(Context context)
		{
			context.Output += "|";
			personalDetails.Interpret(context);
			context.Output += "|";
			patientType.Interpret(context);
			context.Output += "|";
			context.Output += "<--";
			medicalHistory.Interpret(context);
			context.Output += "-";
			diagnosis.Interpret(context);
			context.Output += "-->";
			medication.Interpret(context);
			context.Output += "|";
			Console.WriteLine(context.Output);
		}
	}
}