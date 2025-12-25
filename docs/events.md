# Domain Events - Contracting Platform

Based on analysis of [Zicklin Contracting](https://www.zicklincontracting.com/) - a NYC-based general contracting company with 37+ years of experience.

---

## 1. Customer & Lead Management

| Event | Description |
|-------|-------------|
| `LeadCreated` | A potential customer inquiry was received |
| `LeadQualified` | Lead was assessed and marked as qualified |
| `LeadDisqualified` | Lead was assessed and marked as not viable |
| `CustomerCreated` | New customer account was created |
| `CustomerUpdated` | Customer information was modified |
| `CustomerDeactivated` | Customer account was deactivated |
| `EmergencyContactReceived` | 24/7 emergency service request was received |

---

## 2. Project Management

| Event | Description |
|-------|-------------|
| `ProjectCreated` | New contracting project was initiated |
| `ProjectScheduled` | Project was assigned a start date and timeline |
| `ProjectStarted` | Work on the project commenced |
| `ProjectPaused` | Project was temporarily halted |
| `ProjectResumed` | Paused project was resumed |
| `ProjectCompleted` | All project work was finished |
| `ProjectCancelled` | Project was cancelled before completion |
| `ProjectMilestoneReached` | A key project milestone was achieved |
| `ProjectDelayed` | Project timeline was extended |
| `ProjectPhaseCompleted` | A phase of the project was completed |

---

## 3. Estimation & Bidding

| Event | Description |
|-------|-------------|
| `SiteInspectionScheduled` | On-site evaluation was scheduled |
| `SiteInspectionCompleted` | On-site evaluation was performed |
| `EstimateRequested` | Customer requested a project estimate |
| `EstimateCreated` | Cost estimate was generated |
| `EstimateRevised` | Estimate was modified |
| `EstimateApproved` | Customer approved the estimate |
| `EstimateRejected` | Customer rejected the estimate |
| `EstimateExpired` | Estimate validity period ended |

---

## 4. Contracts & Agreements

| Event | Description |
|-------|-------------|
| `ContractDrafted` | Contract document was created |
| `ContractSent` | Contract was sent to customer for review |
| `ContractSigned` | Contract was signed by all parties |
| `ContractAmended` | Contract terms were modified |
| `ContractTerminated` | Contract was terminated |
| `ChangeOrderRequested` | Change to scope was requested |
| `ChangeOrderApproved` | Change order was approved |
| `ChangeOrderRejected` | Change order was denied |

---

## 5. Permits & Compliance

| Event | Description |
|-------|-------------|
| `PermitApplicationSubmitted` | Permit application filed with authority |
| `PermitApproved` | Permit was granted |
| `PermitDenied` | Permit application was rejected |
| `PermitExpired` | Permit validity ended |
| `PermitRenewed` | Permit was renewed |
| `DOBViolationReceived` | Department of Buildings violation issued |
| `DOBViolationResolved` | DOB violation was cleared |
| `LocalLaw11InspectionScheduled` | Facade inspection was scheduled |
| `LocalLaw11InspectionCompleted` | Facade inspection was performed |
| `LocalLaw11ComplianceAchieved` | Property met Local Law 11 requirements |
| `DEPViolationReceived` | DEP violation was issued |
| `DEPViolationResolved` | DEP violation was resolved |
| `CurbViolationReceived` | Curb violation was issued |
| `CurbViolationResolved` | Curb compliance was achieved |
| `CodeInspectionPassed` | Building code inspection passed |
| `CodeInspectionFailed` | Building code inspection failed |

---

## 6. Demolition & Alteration

| Event | Description |
|-------|-------------|
| `DemolitionPermitObtained` | Demolition permit was secured |
| `DemolitionStarted` | Demolition work began |
| `DemolitionCompleted` | Demolition work finished |
| `DebrisRemovalCompleted` | Site debris was cleared |
| `SitePreparationCompleted` | Site was prepared for construction |
| `AlterationWorkStarted` | Alteration work commenced |
| `AlterationWorkCompleted` | Alteration work finished |

---

## 7. Interior Services

| Event | Description |
|-------|-------------|
| `BasementConversionStarted` | Basement renovation work began |
| `BasementConversionCompleted` | Basement renovation finished |
| `LeakDetectionPerformed` | Leak detection assessment completed |
| `LeakRepairCompleted` | Water leak was repaired |
| `KitchenRenovationStarted` | Kitchen remodel work began |
| `KitchenRenovationCompleted` | Kitchen remodel finished |
| `BathroomRenovationStarted` | Bathroom remodel work began |
| `BathroomRenovationCompleted` | Bathroom remodel finished |
| `FlooringInstalled` | Flooring installation completed |
| `CabinetryInstalled` | Custom cabinetry was installed |
| `CarpentryWorkCompleted` | Carpentry work finished |

---

## 8. Exterior & Roofing Services

| Event | Description |
|-------|-------------|
| `RoofInspectionCompleted` | Roof assessment was performed |
| `RoofRepairStarted` | Roof repair work began |
| `RoofRepairCompleted` | Roof repair finished |
| `RoofReplacementStarted` | Full roof replacement began |
| `RoofReplacementCompleted` | Roof replacement finished |
| `SidingInstalled` | Exterior siding was installed |
| `WindowsInstalled` | Window installation completed |
| `MasonryWorkStarted` | Masonry work commenced |
| `MasonryWorkCompleted` | Masonry work finished |
| `PaversInstalled` | Paver installation completed |
| `LandscapingCompleted` | Landscaping work finished |
| `FacadeRepairCompleted` | Building facade repair finished |

---

## 9. Waterproofing

| Event | Description |
|-------|-------------|
| `WaterproofingAssessmentCompleted` | Waterproofing needs evaluated |
| `BasementWaterproofingStarted` | Basement waterproofing began |
| `BasementWaterproofingCompleted` | Basement waterproofing finished |
| `RoofWaterproofingCompleted` | Roof waterproofing finished |
| `ExteriorWaterproofingCompleted` | Exterior waterproofing finished |
| `DrainageSystemInstalled` | Drainage system was installed |
| `WarrantyIssued` | Waterproofing warranty was issued |

---

## 10. Property Restoration

### Water Damage
| Event | Description |
|-------|-------------|
| `WaterDamageReported` | Water damage incident reported |
| `EmergencyResponseDispatched` | 24/7 emergency team was sent |
| `WaterExtractionStarted` | Water removal process began |
| `WaterExtractionCompleted` | Water removal finished |
| `DryingProcessStarted` | Drying/dehumidification began |
| `DryingProcessCompleted` | Drying process finished |
| `WaterDamageRepairCompleted` | Structural repairs finished |

### Fire & Smoke Damage
| Event | Description |
|-------|-------------|
| `FireDamageAssessed` | Fire damage evaluation completed |
| `SootCleanupStarted` | Soot/debris cleanup began |
| `SootCleanupCompleted` | Soot cleanup finished |
| `OdorRemovalCompleted` | Smoke odor elimination finished |
| `FireDamageRepairCompleted` | Fire damage restoration finished |

### Mold Remediation
| Event | Description |
|-------|-------------|
| `MoldInspectionCompleted` | Mold assessment was performed |
| `MoldContainmentEstablished` | Containment measures in place |
| `MoldRemovalStarted` | Mold removal process began |
| `MoldRemovalCompleted` | Mold removal finished |
| `MoldRemediationCertified` | Area certified mold-free |

---

## 11. Sidewalk Services

| Event | Description |
|-------|-------------|
| `SidewalkViolationReceived` | DOT sidewalk violation issued |
| `SidewalkInspectionCompleted` | Sidewalk condition assessed |
| `SidewalkRepairPermitObtained` | Repair permit was secured |
| `SidewalkRepairStarted` | Sidewalk repair work began |
| `SidewalkRepairCompleted` | Sidewalk repair finished |
| `SidewalkViolationCleared` | DOT violation was resolved |
| `SidewalkSignOffObtained` | Final inspection passed |

---

## 12. HVAC Services

| Event | Description |
|-------|-------------|
| `HVACInspectionCompleted` | HVAC system assessment done |
| `HVACInstallationStarted` | HVAC installation began |
| `HVACInstallationCompleted` | HVAC installation finished |
| `HVACRepairCompleted` | HVAC repair work finished |
| `HVACMaintenancePerformed` | Routine HVAC maintenance done |
| `HVACSystemCommissioned` | New HVAC system was activated |

---

## 13. Townhouse Renovation

| Event | Description |
|-------|-------------|
| `TownhouseAssessmentCompleted` | Full property assessment done |
| `TownhouseRenovationStarted` | Major renovation work began |
| `TownhouseRenovationCompleted` | Renovation project finished |
| `StructuralWorkCompleted` | Structural modifications done |
| `MEPWorkCompleted` | Mechanical/electrical/plumbing done |
| `FinishWorkCompleted` | Final finishes installed |

---

## 14. Insurance Claims

| Event | Description |
|-------|-------------|
| `InsuranceClaimInitiated` | Insurance claim process started |
| `DamageDocumented` | Damage was documented for claim |
| `ClaimSubmitted` | Claim submitted to insurer |
| `ClaimAdjusterScheduled` | Adjuster visit was scheduled |
| `ClaimAdjusterVisitCompleted` | Adjuster completed evaluation |
| `ClaimApproved` | Insurance claim was approved |
| `ClaimDenied` | Insurance claim was denied |
| `ClaimAppealed` | Denied claim was appealed |
| `ClaimSettled` | Insurance claim was settled |
| `InsurancePaymentReceived` | Insurance payment was received |

---

## 15. Invoicing & Payments

| Event | Description |
|-------|-------------|
| `InvoiceGenerated` | Invoice was created |
| `InvoiceSent` | Invoice was sent to customer |
| `PaymentReceived` | Payment was received |
| `PaymentFailed` | Payment attempt failed |
| `DepositReceived` | Initial deposit was received |
| `ProgressPaymentReceived` | Milestone payment received |
| `FinalPaymentReceived` | Final payment received |
| `PaymentOverdue` | Payment passed due date |
| `PaymentReminderSent` | Payment reminder was sent |
| `RefundIssued` | Refund was processed |

---

## 16. Workforce & Scheduling

| Event | Description |
|-------|-------------|
| `CrewAssigned` | Work crew assigned to project |
| `CrewReassigned` | Crew was reassigned |
| `WorkOrderCreated` | Work order was generated |
| `WorkOrderAssigned` | Work order assigned to crew |
| `WorkOrderStarted` | Work order execution began |
| `WorkOrderCompleted` | Work order was completed |
| `DailyReportSubmitted` | Daily work report submitted |
| `EquipmentDeployed` | Equipment sent to job site |
| `MaterialsDelivered` | Materials delivered to site |
| `SubcontractorHired` | Subcontractor was engaged |

---

## 17. Quality & Safety

| Event | Description |
|-------|-------------|
| `QualityInspectionScheduled` | Quality check was scheduled |
| `QualityInspectionPassed` | Work passed quality standards |
| `QualityInspectionFailed` | Work failed quality standards |
| `ReworkRequired` | Rework was identified as needed |
| `ReworkCompleted` | Rework was finished |
| `SafetyIncidentReported` | Safety incident was reported |
| `SafetyInspectionCompleted` | Safety inspection performed |
| `PunchListCreated` | Punch list was generated |
| `PunchListItemCompleted` | Punch list item was resolved |
| `FinalWalkthroughScheduled` | Final walkthrough scheduled |
| `FinalWalkthroughCompleted` | Final walkthrough finished |
| `CustomerSignOffObtained` | Customer approved final work |

---

## 18. Communication & Notifications

| Event | Description |
|-------|-------------|
| `CustomerNotified` | Customer was notified of update |
| `ProjectUpdateSent` | Project status update sent |
| `AppointmentScheduled` | Appointment was scheduled |
| `AppointmentConfirmed` | Appointment was confirmed |
| `AppointmentRescheduled` | Appointment was rescheduled |
| `AppointmentCancelled` | Appointment was cancelled |
| `ReviewRequested` | Customer review was requested |
| `ReviewReceived` | Customer submitted a review |
| `ComplaintReceived` | Customer complaint was received |
| `ComplaintResolved` | Customer complaint was resolved |

---

## Summary

| Feature Category | Event Count |
|-----------------|-------------|
| Customer & Lead Management | 7 |
| Project Management | 10 |
| Estimation & Bidding | 8 |
| Contracts & Agreements | 8 |
| Permits & Compliance | 16 |
| Demolition & Alteration | 7 |
| Interior Services | 11 |
| Exterior & Roofing | 12 |
| Waterproofing | 7 |
| Property Restoration | 17 |
| Sidewalk Services | 7 |
| HVAC Services | 6 |
| Townhouse Renovation | 6 |
| Insurance Claims | 10 |
| Invoicing & Payments | 10 |
| Workforce & Scheduling | 10 |
| Quality & Safety | 12 |
| Communication & Notifications | 10 |
| **Total** | **164** |

---

*Reference: [Zicklin Contracting](https://www.zicklincontracting.com/) - NYC General Contractor with 37+ years of experience in residential, commercial, and industrial contracting services.*
