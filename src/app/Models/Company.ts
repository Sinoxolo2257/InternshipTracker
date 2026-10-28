import { Application } from "./Application";

export interface Company{
    companyId: number;
    companyName: string;
    industry: string;
    companyDescription: string;
    location: string;
    isWishlisted: boolean;
    applications: Application[];
}