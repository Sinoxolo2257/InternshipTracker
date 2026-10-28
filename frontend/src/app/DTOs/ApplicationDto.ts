export interface ApplicationDto{
    positionTitle:string;
    applicationLink:string;
    portalLink:string;
    notes:string;
    openDate: Date;
    closeDate: Date;
    updatedAt: Date;
    userId: number;
    companyId: number;
    statusId: number;
}