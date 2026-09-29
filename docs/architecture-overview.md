# Architecture and Domain Model

## Components
1. TaxCalculation Core: Pure domain class library without external dependencies.
2. TaxCalculation.Tests: Unit testing suite verifying rounding, edge cases, and multi-tax line scenarios.

## Rounding Standards
All currency calculations apply MidpointRounding.AwayFromZero to 5 decimal places as required by ETA specifications.