import type { Meta, StoryObj } from '@storybook/angular';
import { ProcessTimeline } from './process-timeline';

const meta: Meta<ProcessTimeline> = {
  title: 'Components/ProcessTimeline',
  component: ProcessTimeline,
  tags: ['autodocs'],
  argTypes: {
    steps: {
      control: 'object',
      description: 'Array of process steps',
    },
    variant: {
      control: 'select',
      options: ['horizontal', 'vertical'],
      description: 'Timeline orientation',
    },
  },
};

export default meta;
type Story = StoryObj<ProcessTimeline>;

const renovationProcess = [
  {
    number: 1,
    title: 'Free Consult',
    description: 'We visit your home to discuss your vision',
  },
  {
    number: 2,
    title: 'Design Phase',
    description: '3D renderings and material selection',
  },
  {
    number: 3,
    title: 'Quote',
    description: 'Detailed proposal with timeline',
  },
  {
    number: 4,
    title: 'Permit',
    description: 'We handle all NYC required permits',
  },
  {
    number: 5,
    title: 'Build',
    description: 'Professional installation by skilled craftsmen',
  },
  {
    number: 6,
    title: 'Final Check',
    description: 'Quality walkthrough & warranty',
  },
];

export const HorizontalTimeline: Story = {
  args: {
    steps: renovationProcess,
    variant: 'horizontal',
  },
};

export const VerticalTimeline: Story = {
  args: {
    steps: renovationProcess,
    variant: 'vertical',
  },
};

export const SimpleProcess: Story = {
  args: {
    steps: [
      {
        number: 1,
        title: 'Contact',
        description: 'Call or fill out our online form',
      },
      {
        number: 2,
        title: 'Consultation',
        description: 'Free on-site assessment',
      },
      {
        number: 3,
        title: 'Proposal',
        description: 'Detailed quote within 48 hours',
      },
      {
        number: 4,
        title: 'Execution',
        description: 'Quality work, on time',
      },
    ],
    variant: 'horizontal',
  },
};
