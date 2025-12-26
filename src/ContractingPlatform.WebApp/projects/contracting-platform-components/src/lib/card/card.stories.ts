import type { Meta, StoryObj } from '@storybook/angular';
import { ServiceCard } from './service-card';
import { ProjectCard } from './project-card';
import { TestimonialCard } from './testimonial-card';
import { TeamCard } from './team-card';

// Service Card Stories
const serviceCardMeta: Meta<ServiceCard> = {
  title: 'Components/Cards/ServiceCard',
  component: ServiceCard,
  tags: ['autodocs'],
  argTypes: {
    icon: {
      control: 'text',
      description: 'Material icon name',
    },
    title: {
      control: 'text',
      description: 'Card title',
    },
    description: {
      control: 'text',
      description: 'Card description',
    },
    linkText: {
      control: 'text',
      description: 'Link button text',
    },
  },
};

export default serviceCardMeta;
type ServiceCardStory = StoryObj<ServiceCard>;

export const KitchenRenovation: ServiceCardStory = {
  args: {
    icon: 'kitchen',
    title: 'Kitchen Renovation',
    description:
      'Transform your kitchen into the heart of your home with custom cabinetry, countertops, and modern appliances.',
    linkText: 'Learn More',
  },
};

export const BathroomRenovation: ServiceCardStory = {
  args: {
    icon: 'bathroom',
    title: 'Bathroom Renovation',
    description:
      'Modern updates for your bathroom with quality fixtures, tile work, and contemporary designs.',
    linkText: 'Learn More',
  },
};

export const BasementFinishing: ServiceCardStory = {
  args: {
    icon: 'foundation',
    title: 'Basement Finishing',
    description:
      'Convert unused space into beautiful living areas. Includes waterproofing and legalization.',
    linkText: 'Learn More',
  },
};

// Project Card Stories
export const ProjectCardMeta: Meta<ProjectCard> = {
  title: 'Components/Cards/ProjectCard',
  component: ProjectCard,
  tags: ['autodocs'],
};

export const ProjectCardDefault: StoryObj<ProjectCard> = {
  render: (args) => ({
    props: args,
    template: `<cp-project-card [imageUrl]="imageUrl" [title]="title" [category]="category" [location]="location"></cp-project-card>`,
  }),
  args: {
    imageUrl: 'https://placehold.co/400x300/e7e0ec/49454f?text=Kitchen',
    title: 'Modern Kitchen Renovation',
    category: 'Kitchen',
    location: 'Manhattan',
  },
};

// Testimonial Card Stories
export const TestimonialCardMeta: Meta<TestimonialCard> = {
  title: 'Components/Cards/TestimonialCard',
  component: TestimonialCard,
  tags: ['autodocs'],
};

export const TestimonialCardDefault: StoryObj<TestimonialCard> = {
  render: (args) => ({
    props: args,
    template: `<cp-testimonial-card [quote]="quote" [authorName]="authorName" [authorLocation]="authorLocation" [serviceType]="serviceType" [rating]="rating"></cp-testimonial-card>`,
  }),
  args: {
    quote:
      'The construction team was skilled and professional, worked quickly and removed all the trash. The price was very fair and affordable. The new stoop looks great!',
    authorName: 'Sarah M.',
    authorLocation: 'Park Slope, Brooklyn',
    serviceType: 'Exterior/Masonry',
    rating: 5,
  },
};

// Team Card Stories
export const TeamCardMeta: Meta<TeamCard> = {
  title: 'Components/Cards/TeamCard',
  component: TeamCard,
  tags: ['autodocs'],
};

export const TeamCardDefault: StoryObj<TeamCard> = {
  render: (args) => ({
    props: args,
    template: `<cp-team-card [imageUrl]="imageUrl" [name]="name" [role]="role" [description]="description"></cp-team-card>`,
  }),
  args: {
    imageUrl: 'https://placehold.co/150x150/6750a4/ffffff?text=RR',
    name: 'Raja Riasat',
    role: 'CEO & Founder',
    description:
      '30+ years of experience in construction and renovation, bringing quality craftsmanship to every project.',
  },
};
