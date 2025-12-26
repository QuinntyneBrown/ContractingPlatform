import type { Meta, StoryObj } from '@storybook/angular';
import { TrustBadge } from './trust-badge';

const meta: Meta<TrustBadge> = {
  title: 'Components/TrustBadge',
  component: TrustBadge,
  tags: ['autodocs'],
  argTypes: {
    icon: {
      control: 'text',
      description: 'Material icon name',
    },
    title: {
      control: 'text',
      description: 'Badge title',
    },
    subtitle: {
      control: 'text',
      description: 'Badge subtitle',
    },
    variant: {
      control: 'select',
      options: ['default', 'compact'],
      description: 'Badge variant',
    },
  },
};

export default meta;
type Story = StoryObj<TrustBadge>;

export const NYCLicensed: Story = {
  args: {
    icon: 'verified',
    title: 'NYC Licensed',
    subtitle: 'Contractor',
    variant: 'default',
  },
};

export const BBBRated: Story = {
  args: {
    icon: 'workspace_premium',
    title: 'BBB A+',
    subtitle: 'Rated',
    variant: 'default',
  },
};

export const FullyInsured: Story = {
  args: {
    icon: 'security',
    title: 'Fully Insured',
    variant: 'default',
  },
};

export const FamilyOwned: Story = {
  args: {
    icon: 'family_restroom',
    title: 'Family Owned',
    subtitle: 'Since 1987',
    variant: 'default',
  },
};

export const Compact: Story = {
  args: {
    icon: 'verified',
    title: 'NYC Licensed',
    subtitle: 'Contractor',
    variant: 'compact',
  },
};
