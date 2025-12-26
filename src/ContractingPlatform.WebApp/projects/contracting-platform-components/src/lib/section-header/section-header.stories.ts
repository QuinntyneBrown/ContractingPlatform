import type { Meta, StoryObj } from '@storybook/angular';
import { SectionHeader } from './section-header';

const meta: Meta<SectionHeader> = {
  title: 'Components/SectionHeader',
  component: SectionHeader,
  tags: ['autodocs'],
  argTypes: {
    title: {
      control: 'text',
      description: 'Section title',
    },
    subtitle: {
      control: 'text',
      description: 'Section subtitle',
    },
    alignment: {
      control: 'select',
      options: ['left', 'center', 'right'],
      description: 'Text alignment',
    },
  },
};

export default meta;
type Story = StoryObj<SectionHeader>;

export const OurServices: Story = {
  args: {
    title: 'Our Services',
    subtitle: 'Comprehensive contracting solutions tailored to your needs',
    alignment: 'center',
  },
};

export const FeaturedProjects: Story = {
  args: {
    title: 'Featured Projects',
    subtitle: "See our recent work across NYC's five boroughs",
    alignment: 'center',
  },
};

export const WhyChooseUs: Story = {
  args: {
    title: 'Why Choose Us',
    subtitle: 'A family-owned business you can trust',
    alignment: 'center',
  },
};

export const LeftAligned: Story = {
  args: {
    title: 'Our Story',
    subtitle: 'Learn about our 37-year journey serving NYC homeowners',
    alignment: 'left',
  },
};

export const TitleOnly: Story = {
  args: {
    title: 'Customer Testimonials',
    alignment: 'center',
  },
};
