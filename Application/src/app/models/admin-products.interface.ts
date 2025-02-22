export interface User {
    name: string;
    email: string;
    avatar?: string;
    avatarInitials?: string;
    isTopEndorsed?: boolean;
    position: {
      title: string;
      department: string;
    };
    country: string;
    status: 'Active' | 'Pending' | 'Suspended';
  }