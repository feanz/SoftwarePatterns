Define:
	To divide a complex set of business logic into a set of separate business rules.  This separates the rules logic from the process by which rules are applied. 

Intent:
	Separate individual rules from processing logic
	Allow rules  to be added without the need for changes in the rest of the system

Considerations:
	Good idea to keep rules read only so they have little effect on other parts of the system
	Try and reduce rule dependencies where possible
	Do rules need to be run in explicit order
	Rules could have a priority order which they can then be ordered by
	Some rules may trump others so you may want to include halt mechanism
	You may need to be able to persist rules and let end user edit them
