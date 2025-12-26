import type { Meta, StoryObj } from '@storybook/angular';
import { HeroSection } from './hero-section';

const meta: Meta<HeroSection> = {
  title: 'Components/HeroSection',
  component: HeroSection,
  tags: ['autodocs'],
  argTypes: {
    title: {
      control: 'text',
      description: 'Main heading',
    },
    subtitle: {
      control: 'text',
      description: 'Subtitle text',
    },
    breadcrumb: {
      control: 'text',
      description: 'Breadcrumb navigation text',
    },
    backgroundImage: {
      control: 'text',
      description: 'Background image URL',
    },
    overlayOpacity: {
      control: { type: 'range', min: 0, max: 1, step: 0.1 },
      description: 'Dark overlay opacity',
    },
    primaryButtonText: {
      control: 'text',
      description: 'Primary button text',
    },
    secondaryButtonText: {
      control: 'text',
      description: 'Secondary button text',
    },
    variant: {
      control: 'select',
      options: ['full', 'compact'],
      description: 'Hero size variant',
    },
  },
};

export default meta;
type Story = StoryObj<HeroSection>;

export const Homepage: Story = {
  args: {
    title: "NYC's Trusted General Contractor",
    subtitle: 'Quality Renovations & Restoration Services Since 1987',
    primaryButtonText: 'Get Free Estimate',
    secondaryButtonText: 'Call (718) 550-2779',
    backgroundImage: 'https://placehold.co/1920x1080/1c1b1f/ffffff?text=Hero+Background',
    overlayOpacity: 0.6,
    variant: 'full',
  },
};

export const ServicesPage: Story = {
  args: {
    title: 'Our Services',
    subtitle: 'Comprehensive Contracting Solutions for NYC',
    breadcrumb: 'Home > Services',
    backgroundImage: 'https://placehold.co/1920x600/1c1b1f/ffffff?text=Services',
    overlayOpacity: 0.7,
    variant: 'compact',
  },
};

export const ProjectsPage: Story = {
  args: {
    title: 'Our Projects',
    subtitle: "See Our Work Across NYC's Five Boroughs",
    breadcrumb: 'Home > Projects',
    backgroundImage: 'https://placehold.co/1920x600/1c1b1f/ffffff?text=Projects',
    overlayOpacity: 0.7,
    variant: 'compact',
  },
};

export const AboutPage: Story = {
  args: {
    title: 'About Our Company',
    subtitle: 'Family-Owned, NYC-Built Since 1987',
    breadcrumb: 'Home > About Us',
    backgroundImage: 'https://placehold.co/1920x600/1c1b1f/ffffff?text=About',
    overlayOpacity: 0.7,
    variant: 'compact',
  },
};

export const ContactPage: Story = {
  args: {
    title: 'Contact Us',
    subtitle: 'Get Your Free Estimate Today',
    breadcrumb: 'Home > Contact',
    backgroundImage: 'https://placehold.co/1920x600/1c1b1f/ffffff?text=Contact',
    overlayOpacity: 0.7,
    variant: 'compact',
  },
};
