export type ListingType = 'Job' | 'Internship' | 'Bursary';

export interface User {
  userID: number;
  name: string;
  surname: string;
  emailAddress: string;
}

export interface Company {
  companyID: number;
  companyName: string;
  industry: string | null;
  companyDescription: string | null;
  isWishlisted: boolean;
}

export interface Listing {
  listingID: number;
  companyID: number;
  companyName: string;
  title: string;
  type: ListingType;
  location: string | null;
  openDate: string | null;     
  closeDate: string;
  requirements: string;
  description: string | null;
  applicationLink: string | null;
}

export interface Application {
  applicationID: number;
  listingID: number;
  title: string;
  companyID: number;
  companyName: string;
  location: string | null;
  type: ListingType;
  openDate: string | null;
  closeDate: string;
  statusID: number;
  status: string;
  submittedDate: string | null;
  portalLink: string | null;
  notes: string | null;
  versionID: number | null;
  updatedAt: string;
}

export interface Cv {
  versionID: number;
  versionName: string;
  originalFileName: string;
  uploadedAt: string;
  docIsActive: boolean;
}

export type CompanyRequest = Omit<Company, 'companyID'>;
export type ListingRequest = Omit<Listing, 'listingID' | 'companyName'>;

export interface ApplicationRequest {
  listingID: number;
  versionID: number | null;
  statusID: number;
  submittedDate: string | null;
  portalLink: string | null;
  notes: string | null;
}


export const APPLICATION_STATUSES = [
  { statusID: 1, label: 'Saved' },
  { statusID: 2, label: 'Applied' },
  { statusID: 3, label: 'In Review' },
  { statusID: 4, label: 'Interview Scheduled' },
  { statusID: 5, label: 'Offered' },
  { statusID: 6, label: 'Rejected' },
  { statusID: 7, label: 'Withdrawn' },
] as const;

export const SAVED_STATUS_ID = 1;