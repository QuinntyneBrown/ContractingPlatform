import type { Meta, StoryObj } from '@storybook/angular';
import { Statistic } from './statistic';

const meta: Meta<Statistic> = {
  title: 'Components/Statistic',
  component: Statistic,
  tags: ['autodocs'],
  argTypes: {
    value: {
      control: 'text',
      description: 'The statistic value',
    },
    label: {
      control: 'text',
      description: 'The label below the value',
    },
    suffix: {
      control: 'text',
      description: 'Suffix after the value (e.g., "+", "%")',
    },
    variant: {
      control: 'select',
      options: ['default', 'inverted'],
      description: 'Color variant',
    },
  },
};

export default meta;
type Story = StoryObj<Statistic>;

export const YearsExperience: Story = {
  args: {
    value: '37',
    suffix: '+',
    label: 'Years Experience',
    variant: 'default',
  },
};

export const ProjectsCompleted: Story = {
  args: {
    value: '6,500',
    suffix: '+',
    label: 'Projects Completed',
    variant: 'default',
  },
};

export const BoroughsServed: Story = {
  args: {
    value: '5',
    label: 'Boroughs Served',
    variant: 'default',
  },
};

export const EmergencyService: Story = {
  args: {
    value: '24/7',
    label: 'Emergency Response',
    variant: 'default',
  },
};

export const Inverted: Story = {
  args: {
    value: '37',
    suffix: '+',
    label: 'Years Experience',
    variant: 'inverted',
  },
  parameters: {
    backgrounds: {
      default: 'dark',
    },
  },
  decorators: [
    (story) => ({
      template: `<div style="background-color: #6750a4; padding: 24px;">${story().template}</div>`,
      props: story().props,
    }),
  ],
};
