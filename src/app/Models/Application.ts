import { User } from "./User";
import { Company } from "./Company";
import { ApplicationStatus } from "./ApplicationStatus";
import { Document } from "./Document";

export interface Application{
    applicationId:number;
    applicationDate: Date;
    positionTitle:string;
    applicationLink:string;
    portalLink:string;
    notes:string;
    openDate: Date;
    closeDate: Date;
    updatedAt: Date;
    user: User;
    company: Company;
    applicationStatus: ApplicationStatus;
    documents: Document[];
}